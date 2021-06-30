// Esse é o scriptpai para o controle do atual armamento e qualquer outro armamento que venha colocar no jogo, como tenho intenção de futuramente colocar outros tipos de armamento o uso desse script pai ajuda muito no controle e tamanho dos codigos dos armamentos em especifico.
// Aqui controlo a interação do objeto(arma) com as interações que o XRGrabInteractable permite, em especifico com o on Select Entered/on Select Exited(pegou ou não o objeto) e On activate/ On Deactivate(Acionado pelo Activate Usage do script XRController)
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
// Componentes obrigatorios para o script
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]

//Classe pai para os demais armamentos
public class Weapon : MonoBehaviour
{
    //************************************************** Variaveis ***************************************************************************************************
    [SerializeField] protected float shootingForce; //Força do disparo
    [SerializeField] protected Transform bulletSpawn; //Posição da munição caso seja usado um objeto para simular o projetil, melhor em casos de armamentos com baixa cadencia de tiro
    [SerializeField] private float recoilForce; //Força do recuo aprocado no armamento caso seja necessario
    [SerializeField] private float damage; // Dano que o armamento especifico ira gerar

    private Rigidbody rigidBody;
    private XRGrabInteractable interactableWeapon;

    //*************************************************** Código *****************************************************************************************

    //Ao instanciar o script pego essas 3 componentes, em especial para as linhas 35 e 37 que pegam as componentes do XRGrabInteractable e chama o metodo SetupInteractableWeaponEvents() que é quem estabelecem os parametros para as funções desse metodo
    protected virtual void Awake()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }


    //estabelece o metodo que sera chamado dentro dos parametros do XRGrabInteractable
    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.onSelectEntered.AddListener(PickUpWeapon);
        interactableWeapon.onSelectExited.AddListener(DropWeapon);
        interactableWeapon.onActivate.AddListener(StartShooting);
        interactableWeapon.onDeactivate.AddListener(StopShooting);
    }

    //Esconder a mão quando pegar o armamento
    private void PickUpWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHidder>().Hide();
    }
 
    //Mostrar a mão quando soltar o objeto
    private void DropWeapon(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHidder>().Show();

    }

    //iniciar o disparo quando o botão que representa o Activate Usage do script XRController for precionado
     
    protected virtual void StartShooting(XRBaseInteractor interactor)
    {

    }

    //parar o disparo quando o botão que representa o Activate Usage do script XRController for liberado
    protected virtual void StopShooting(XRBaseInteractor interactor)
    {

    }

    //Chama o disparo do armamento e caso necessario o recuo do mesmo
    protected virtual void Shoot()
    {
        ApplyRecoil();
    }


    //recuo do armamenbto
    private void ApplyRecoil()
    {
        rigidBody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    //força do disparo
    public float GetShootingForce()
    {
        return shootingForce;
    }

    //Dano do disparo
    public float GetDamage()
    {
        return damage;
    }
}
