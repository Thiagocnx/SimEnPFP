// A intecção desse script é possinilitar que o jogador possa controlar o armamento com ambas as mãos para isso foi utilizado o pacote da unity XR Interaction ToolKit
//Ele permite fazer uma lista a partir da interações simples, para isso basta colocar o objeto passivel de interação
//
//Autor do Código: Thiago da Silva Gonçalves, matricula 2012400
//
//==================================================================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

// A classe TwoHandGrabInteractable é uma Subclasse do XRGrabInteractable para possibiliatar a herança de suas variaveis e rotinas;
public class TwoHandGrabInteractable : XRGrabInteractable
{
    //************************************************** Variaveis ***************************************************************************************************
    public List<XRSimpleInteractable> secondHandGrabPoints = new List<XRSimpleInteractable>(); // Listar os objetos para interação no segundo ponto de pagada no armamento
    private XRBaseInteractor secondInteractor; // variavel de interação em ambiente virtual
    private Quaternion attachInitialRotation; // Variavel para controle da rotação do objeto
    
    // conjunto que vai definir qual o local de pegada dominate para definir a rotação
    public enum TwoHandRotationType { None,First,Second};
    public TwoHandRotationType twoHandRotationType;

    //*************************************************** Código *****************************************************************************************

    // Start is called before the first frame update
    //Verifica se o objeto está sendo segurado ou não
    void Start()
    {
        foreach (var item in secondHandGrabPoints)
        {
            item.onSelectEntered.AddListener(OnSecondHandGrab);
            item.onSelectExited.AddListener(OnSecondHandRelease);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Verifica se ambos os pontos de inteção foram pegos para assim poder retornar sua rotação
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (secondInteractor && selectingInteractor)
        {
            //Computa a rotação
            selectingInteractor.attachTransform.rotation = GetTwoHandRotaton();

        }
        base.ProcessInteractable(updatePhase);
    }

    //Computa a rotação a partir da definição do ponto de pega determinante(None, First, Second)
    private Quaternion GetTwoHandRotaton()
    {
        Quaternion targetRotation;
        if (twoHandRotationType == TwoHandRotationType.None)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position);
        }
        else if (twoHandRotationType == TwoHandRotationType.First)
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, selectingInteractor.attachTransform.up);
        }
        else
        {
            targetRotation = Quaternion.LookRotation(secondInteractor.attachTransform.position - selectingInteractor.attachTransform.position, secondInteractor.attachTransform.up);
        }

        return targetRotation;
    }

    //************************************ Conjunto para verificar o estado de seleção do objeto e sua rotação inicial ****************************************
    public void OnSecondHandGrab(XRBaseInteractor interactor)
    {
        secondInteractor = interactor;
    }

    public void OnSecondHandRelease(XRBaseInteractor interactor)
    {
        secondInteractor = null;
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        attachInitialRotation = interactor.attachTransform.localRotation;
    }
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        secondInteractor = null;
        interactor.attachTransform.localRotation = attachInitialRotation;
    }
    //*********************************************************************************************************************************************************

    // Evitar  superposição da interação de um objeto com ambas as mãos.
    public override bool IsSelectableBy(XRBaseInteractor interactor)
    {
        bool isalreadygrabbed = selectingInteractor && !interactor.Equals(selectingInteractor);
        return base.IsSelectableBy(interactor) && !isalreadygrabbed;
    }
}
