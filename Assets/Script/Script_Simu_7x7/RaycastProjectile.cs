// Atravez do Raycast verifica se houve contato com algum objeto que tenha herança do ITakeDamage
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe filha da classe Projectile
public class RaycastProjectile : Projectile
{
    //*************************************************** Código *****************************************************************************************

    //Verifica se houve uma colisão do disparo com algum objeto que tenha herança do ITakeDamage, sendo verdadeiro ele guarda os valores das variaveis weapon, projectile e posição
    public override void Launch()
    {
        base.Launch();
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            ITakeDamage[] damageTakers = hit.collider.GetComponentsInParent<ITakeDamage>();
            foreach (var taker in damageTakers)
            {
                taker.TakeDamage(weapon, this, hit.point);
            }
        }
    }
}
