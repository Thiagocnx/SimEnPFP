using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSoource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;
        audioSoource.PlayOneShot(audioClip);
        Destroy(spawnedBullet, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
