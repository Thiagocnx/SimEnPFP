// Controle da animações no cenario de treinamento para alinha de tiro 2
//
//Autor do Código: Thiago da Silva Gonçalves
//
//==================================================================================================================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagertConLi2 : MonoBehaviour
{
    //*************************************************** Código *****************************************************************************************
    
    //Variaveis para ativar/resetar o trigger da animação
    const string TARANIM1_1 = "TarAnim1_1";
    const string TARANIM1_2 = "TarAnim1_2";
    const string TARANIM1_3 = "TarAnim1_3";
    const string TARANIM2_1 = "TarAnim2_1";
    const string TARANIM2_2 = "TarAnim2_2";
    const string TARANIM2_3 = "TarAnim2_3";
    const string TARANIM3_1 = "TarAnim3_1";
    const string TARANIM3_2 = "TarAnim3_2";
    const string TARANIM3_3 = "TarAnim3_3";

    //Variaveis para dar acesso ao componentes das animações
    public Animator animator1_1;
    public Animator animator1_2;
    public Animator animator1_3;
    public Animator animator2_1;
    public Animator animator2_2;
    public Animator animator2_3;
    public Animator animator3_1;
    public Animator animator3_2;
    public Animator animator3_3;

    private int x; //Usada para fazer uma seleção randomica
    private float timeTarget = 3.0f;// tempo para chamar o metodo TargetControl() de chamada das animações

    //*************************************************** Código *****************************************************************************************
    // Start is called before the first frame update
    private void Awake()
    {
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Timetarget());
    }
    private IEnumerator Timetarget() //resetar a animaçòes para que possam ser chamadas novamente e controlar o tempo que o metodo TargetControl() será chamado 
    {
        animator1_1.ResetTrigger(TARANIM1_1);
        animator1_2.ResetTrigger(TARANIM1_2);
        animator1_3.ResetTrigger(TARANIM1_3);
        animator2_1.ResetTrigger(TARANIM2_1);
        animator2_2.ResetTrigger(TARANIM2_2);
        animator2_3.ResetTrigger(TARANIM2_3);
        animator3_1.ResetTrigger(TARANIM3_1);
        animator3_2.ResetTrigger(TARANIM3_2);
        animator3_3.ResetTrigger(TARANIM3_3);
        yield return new WaitForSeconds(timeTarget);
        TargetControl();
    }
    void TargetControl() //atravez de uma seleçao randomica, ativa uma das animações
    {
        x = Random.Range(1, 10);
        switch (x)
        {
            case 9:
                animator3_3.SetTrigger(TARANIM3_3);
                break;
            case 8:
                animator3_2.SetTrigger(TARANIM3_2);
                break;
            case 7:
                animator3_1.SetTrigger(TARANIM3_1);
                break;
            case 6:
                animator2_3.SetTrigger(TARANIM2_3);
                break;
            case 5:
                animator2_2.SetTrigger(TARANIM2_2);
                break;
            case 4:
                animator2_1.SetTrigger(TARANIM2_1);
                break;
            case 3:
                animator1_3.SetTrigger(TARANIM1_3);
                break;
            case 2:
                animator1_2.SetTrigger(TARANIM1_2);
                break;
            case 1:
                animator1_1.SetTrigger(TARANIM1_1);
                break;
            default:
                break;
        }
        
        
    }
}
