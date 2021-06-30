using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool inicio = false;
    public static int pont;
    
    // Start is called before the first frame update
    void Start()
    {
        pont = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ready"))
        {
            inicio = true;
        }
        if (other.gameObject.CompareTag("GreenTarget"))
        {
            pont += 1;
        }
        if (other.gameObject.CompareTag("RedTarget"))
        {
            pont -= 1;
        }
    }
}
