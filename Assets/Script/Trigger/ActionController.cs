using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public Player player;
    public EnemyAI enemyAI;
    public bool action = false;

   

    // Start is called before the first frame update
    void Start()
    {
  
    }
    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTrigger")
       {
            action = true;
        }
    }
   

}
