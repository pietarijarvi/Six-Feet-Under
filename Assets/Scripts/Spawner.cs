using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] private float maxSpawn;
	[SerializeField] private float minSpawn;
	[SerializeField] private GameObject[] obj;
	private Random randomSecs = new Random();
	void Start () {
//		Spawn();
		StartCoroutine(Spawn());
	}
	
	IEnumerator Spawn()
	{
		while (true) {
			yield return new WaitForSeconds(Random.Range(minSpawn,maxSpawn));
			Instantiate (obj[Random.Range (0, obj.GetLength(0))], gameObject.transform.position, Quaternion.identity);
		}
	}
}
