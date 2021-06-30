//Gera o efeito de um impacto de um projétil na parede
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallEffect : MonoBehaviour, ITakeDamage
{
    //************************************************** Variaveis ***************************************************************************************************
    [SerializeField] private ParticleSystem wallHole; //Variavel obrigatoria que pega a particula que irá fazer o efeito no local atingido pelo disparo

    //*************************************************** Código *****************************************************************************************
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    //Como todos as outras interações com disparo ele usa parametros do ITakeDamage para verificar a posição da arma e gerar o efeito na direção correta
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        ParticleSystem effect = Instantiate(wallHole, contactPoint, Quaternion.LookRotation(weapon.transform.position - contactPoint));
        effect.Stop();
        effect.Play();
    }
}
