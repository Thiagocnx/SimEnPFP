//Gerenciador das ações do NPC, aqui estão os parametros para iniciar suas reações e de detecção do jogador
//Como o unity permite inserir metodos para serem chamados durate um determinado momento de uma animação, os metodos EnablePistol e Shoot são chamados direto da animação
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//
public class EnemyAI : MonoBehaviour, ITakeDamage
{
    //************************************************** Variaveis ***************************************************************************************************
    
    //Conjunto para definir qual animação será executada a depender das condições
    const string DIED_TRIGGER = "Died";
    const string IDLE_TRIGGER = "Idle";
    const string SHOOT_TRIGGER = "Shoot";

    
    [SerializeField] private float startingHealth; //Valor da vida inicial do NPC
    [SerializeField] private float timeToShoot; //intervalo entre os disparos
    [SerializeField] private float rotationSpeed; // velocidade re rotação do NPC para encontra o jogador
    [SerializeField] private float damage; //Dano que o NPC causa no Jogador
    [Range(0, 100)]
    [SerializeField] private float shootingAccuracy;//Precisão do NPC no disparo

    [SerializeField] private Transform shootingPosition; //posição de onde sairá o disparro do NPC
    [SerializeField] private ParticleSystem bloodSplatterFX;// Efeito de sangramento quando o NPC é atingido
    [SerializeField] private ParticleSystem fpsPistol;// Efeito do disparo do armamento do NPC

    private Animator animator; //paramentro para ter acesso e controlar as animações
    private bool rotation = true; 

    public float maxDistance; // distancia maxima para o NPC detectar o Jogador
    public Player player;
    public ActionController actionController; //Classe ActionController que contem o trigger para iniciar a ação de disparo
    
    //Conjunto para controlar o som e a fonte do som do disparo do armamento do NPC
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioSource audioSourcePistol;
    public AudioClip audioClipPistol;

    public GameObject pistol; //Armamento do NPC
    
    //Vida do NPC
    private float _health;
    public float health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = Mathf.Clamp(value, 0, startingHealth);
        }
    }

    //*************************************************** Código *****************************************************************************************
    
    //O NPC começa com a animação padrão(Idle) e com a vida no maximo 
    private void Awake()
    {
        
        animator = GetComponent<Animator>();
        animator.SetTrigger(IDLE_TRIGGER);
        _health = startingHealth;
        
    }

    private void Start()
    {

    }

  
    //Essa atualização busca se o jogador entrou no alcance do NPC é ativou o trigger de ação
    //Essa posição é calculada a partir da distancia do Jogador ate o NPC
    private void Update()
    {
        if (rotation)
        {
            RotateTowardsPlayer();
        }
        Vector3 orientation = player.GetHeadPosition() - transform.position;

        bool action = actionController.action;
        if (orientation.sqrMagnitude <= 16.0f && action) 
        {  
            StartShooting();   
        }
    }
   
    //Metodo que chama animação de morte do NPC e para de executar a rotação e a fonte de audio
    private void Died()
    {
        audioSource.enabled = false;
        rotation = false;
        animator.SetTrigger(DIED_TRIGGER);
    }

    //Chama a animação de disparo do NPC, dentro da animação quando o npc esta com o armamento apontado para a direção do jogado é chamado o metodo Shoot
    private void StartShooting()
    {
        animator.SetTrigger(SHOOT_TRIGGER);
    }

    //O Shott faz um teste de precisão que caso dando positivo, usa o Raycast atingir o jogador.
    //Com a colisão o jogador toma o dano equivalente do armamento do NPC
    public void Shoot()
    {
        bool hitPlayer = UnityEngine.Random.Range(0, 100) < shootingAccuracy;

        if (hitPlayer)
        {
            RaycastHit hit;
            Vector3 direction = player.GetHeadPosition() - shootingPosition.position;
            if(Physics.Raycast(shootingPosition.position, direction, out hit))
            {
                Player player = hit.collider.GetComponentInParent<Player>();
                if (player)
                {
                    fpsPistol.Play();
                    player.TakeDamage(damage);
                    audioSourcePistol.PlayOneShot(audioClipPistol);
                    
                }
            }
        }
    }

    //Metodo para fazer o NPC ficar de frente para o Jogador, controlando a sua rotação
    public void RotateTowardsPlayer()
    {
        Vector3 direction = player.GetHeadPosition() - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        transform.rotation = rotation;
    } 


    //Controla o dano que o NPC recebe, a partir dos valores no ITakeDamage
    //Verifico qual armamento foi usado e qual seu dano, assim subtraio o valor desse dano da vida do NPC
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        health -= weapon.GetDamage();
        audioSource.PlayOneShot(audioClip); //som de recebimento de disparo
        if (health <= 0) // caso a vida seja menor que 0 chama o metodo Died para executar a animação de morte
            Died();
        ParticleSystem effect = Instantiate(bloodSplatterFX, contactPoint, Quaternion.LookRotation(weapon.transform.position - contactPoint)); //efeito de particulas para representar o sangramento
        effect.Stop();
        effect.Play();
    }

    //Habilitar a exibição do armamento, que será executado em certo momento da animação
    public void EnablePistol()
    {
        pistol.gameObject.SetActive(true);
    }


}
