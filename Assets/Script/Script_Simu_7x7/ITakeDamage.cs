// A intenção aqui é criar uma interface que vai conter algumas definições para um grupo de funcionalidades relacionadas ao dono, força do impacto e posição que o disparo do jogador vai realizar.
// Assim, todos os scripts que vão estar nos objetos que terão interação com os disparos do jogador terão as heranças dessa interface.
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Aqui estão os parametros que serão utilizados para os disparos do jogador.
public interface ITakeDamage
{
    void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint);
}
