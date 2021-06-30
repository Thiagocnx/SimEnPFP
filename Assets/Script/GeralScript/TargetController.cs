using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
	public GameObject[] alvo;
	public Vector3 PosCriacao;
	public int ContaAlvos;
	public float EsperaCriacao;
	private int aa = 0;
	private int restart = 2;
	//public GameController s;


	void Start()
	{
		//bool s = GetComponent<GameController>();
		
	}

    //if (GameController.inicio)
    //

    private void FixedUpdate()
    {
		if (restart >= ContaAlvos)
        {
			aa = 0;
			GameController.inicio = false;
			restart = 2;
		}
		if (GameController.inicio && aa==0) 
        {
			StartCoroutine(SpawnTarget());
			aa++;	
		}
		

	}

    public IEnumerator SpawnTarget()
	{
		for (int i = 0; i < ContaAlvos; i++)
		{
			restart++;
			GameObject a = alvo[Random.Range(0, alvo.Length)];
			Vector3 spawnPosition = new Vector3(Random.Range(5, -1), PosCriacao.y, Random.Range(7, PosCriacao.z));
			Instantiate(a, spawnPosition, Quaternion.Euler(0, 90, 0));
			Destroy(GameObject.Find("Target1(Clone)"), 1.5f);
			Destroy(GameObject.Find("Target2(Clone)"), 0.75f);
			Destroy(GameObject.Find("Target3(Clone)"), 1.5f);
			Destroy(GameObject.Find("Target4(Clone)"), 0.75f);
			Destroy(GameObject.Find("Target5(Clone)"), 0.75f);
			Destroy(GameObject.Find("Target6(Clone)"), 1.5f);
			yield return new WaitForSeconds(EsperaCriacao);	
		}

	}
}
