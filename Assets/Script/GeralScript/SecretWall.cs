using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWall : MonoBehaviour
{
    public Animator wall;
    public Animator swatAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Lever")
        {
            wall.SetBool("Open", true);
            swatAnimator.SetBool("Contact", true);
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
