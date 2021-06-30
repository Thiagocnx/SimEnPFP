//Contrala algumas funções basicas do jogador como a sua posição e vida
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //************************************************** Variaveis ***************************************************************************************************
    [SerializeField] float health; //Vida do Jogador
    [SerializeField] Transform head; //Pega a posição da cabeça do jogador, pois é o ponto mais confiavel por se tratar de um jogo que usa um HMD
    public static float life; // Variavel que permite converter a vida do jogador em modo texto

    public bool contact = false;

    //*************************************************** Código *****************************************************************************************
    public void TakeDamage(float damage) //calcula o dano que o jogador recebeu
    {
        health -= damage;
    }

    public Vector3 GetHeadPosition() //Pega a posição da cabeça do jogador
    {
        return head.position;
    }
    private void Update() // copia o valor da vida para uma variavel que permite a conversão em texto em outro script
    {
        life = health;
    }
}

