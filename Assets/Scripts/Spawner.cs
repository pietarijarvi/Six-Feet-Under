using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] private float maxSpawn;
	[SerializeField] private float minSpawn;
	[SerializeField] private GameObject[] obj;
	void Start () {
//		Spawn();
		InvokeRepeating ("Spawn", maxSpawn, minSpawn);
	}
	
	void Spawn()
	{
	//	Vector3 viewpos = cam.WorldToViewportPoint(new Vector3());
		Instantiate (obj[Random.Range (0, obj.GetLength(0))], gameObject.transform.position, Quaternion.identity);
	}
}
