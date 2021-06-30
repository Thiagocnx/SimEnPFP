using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class ButtonTrigger : MonoBehaviour
{
    public Animator Wall;

    [SerializeField]

    private UnityEvent onButtonPressed;

    private bool pressedInProgress = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Button" && !pressedInProgress)
        {
            pressedInProgress = true;
            Wall.SetBool("Open", true);
            onButtonPressed?.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
