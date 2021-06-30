// Usado nos cubos testes de disparo
//Quando o cubo é atingido ele sofre influenci da força do disparo e sofre uma movimentação como resultado disso
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Como o objetivo é aplicar uma força do cubo é obrigatorio a presença da componente rigidbory
[RequireComponent(typeof(Rigidbody))]

//Para interagir com o disparo ela usa parametros da interface ITakeDamage em especifico da variavel weapon
public class PhysicsDamage : MonoBehaviour, ITakeDamage
{
    //************************************************** Variaveis ***************************************************************************************************
    private Rigidbody rigidBody;

    //*************************************************** Código *****************************************************************************************
    //Componente rigidbody do cubo
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    //Força que é adicionada ao cubo apos ser atingido
    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        rigidBody.AddForce(projectile.transform.forward * weapon.GetShootingForce(), ForceMode.Impulse);
    }
}
