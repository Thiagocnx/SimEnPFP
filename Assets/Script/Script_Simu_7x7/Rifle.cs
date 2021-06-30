// Aqui serão implementados todos os efeitos e funções que o fuzil irá executar durante o jogo
// Como o codigo trata dos assuntos especificos do armamento Fuzil ele vai ser uma subclasse da classe Weapon e assim herdar todas as propriedades, atributos e métodos
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//Subclasse da classe weapon
public class Rifle : Weapon
{
    //************************************************** Variaveis ***************************************************************************************************
    [SerializeField] private Transform effectPosition; // trata a posição onde o efeito do disparo ira acontecer
    [SerializeField] private ParticleSystem fpsRifle; //objeto que trata as particulas do efeito do disparo
    [SerializeField] private float fireRate; // Cadencia de tiro do armamento
    private Projectile projectile; // Variavel para alguns parametros da classe Projectile

    private WaitForSeconds wait; // Intervalo dos disparos

    // trata o efeito sonoro do disparo
    public AudioSource audioSoource;
    public AudioClip audioClip;

    //*************************************************** Código *****************************************************************************************
    
    protected override void Awake()
    {
        base.Awake();
        projectile = GetComponentInChildren<Projectile>(); //ter acesso as componentes filhas da classe Projectile
    }

    private void Start()
    {
        wait = new WaitForSeconds(1 / fireRate); //Regula a cadencia de tiro do armamento dentro do ShootingCO
        projectile.Init(this); // chama a função que está na classe projectile da linha 9
    }

    // Metodo herança da classe Weapon que permite o disparo a partir do acionamento do botão que esta selecionado no Activate usage do XR Controller
    protected override void StartShooting(XRBaseInteractor interactor) 
    {
        base.StartShooting(interactor); // chama o metodo para execução
        StartCoroutine(ShootingCO()); // Inicia a corrotina do disparo
    }

    // Aqui acontece o controle da cadencia do disparo
    private IEnumerator ShootingCO()
    {
        while (true)
        {
            Shoot();
            yield return wait;
        }
    }

    //Executa toda a cinematica do disparo(Lançamento do ropetil, efeitos visuais e sonoros)
    protected override void Shoot() 
    {
        base.Shoot(); // chama o metodo para execução
        projectile.Launch(); //chama o metodo Launch da classe Projectile para execução
        fpsRifle.Play(); // efeito visual das particulas no momento do disparo
        audioSoource.PlayOneShot(audioClip); // efeito sonoros no momento do disparo


    }

    // Metodo herança da classe Weapon que permite interrompe o disparo no momento que o botão que esta selecionado no Activate usage do XR Controller não estiver precionado
    protected override void StopShooting(XRBaseInteractor interactor)
    {
        base.StopShooting(interactor); // chama o metodo para execução
        StopAllCoroutines(); //Para todas as corrotinas
    }
}
