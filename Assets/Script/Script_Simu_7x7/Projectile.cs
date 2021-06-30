// Gerencia o dispara do armamento, sendo a base para a implementação do disparo usando o raycast
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected Weapon weapon; // Variavel para da acesso a alguns parametros da classe Weapon

    //Pegar alguns parametros da classe Weapon para a varial weapon local que são utilizados na classe Rifle
    public virtual void Init(Weapon weapon)
    {
        this.weapon = weapon;
    }

    //Criada para iniciar o disparo dentro das subclasses, sua execução acontece de acordo com o tipo de disparo. No trabalho estamos uando o raycast para o fuzil, sendo assim sua execução acontece dentro da subclasse RaycastProjectile
    //Em uma futura mudança usarei uma variação para o disparo usando um objeto como projetil
    public virtual void Launch()
    {

    }
}
