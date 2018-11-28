using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] obj;
	void Start () {
		Spawn();
		InvokeRepeating ("Spawn", 2f, 1.5f);
	}
	
	void Spawn()
	{
	//	Vector3 viewpos = cam.WorldToViewportPoint(new Vector3());
		Instantiate (obj[Random.Range (0, obj.GetLength(0))], gameObject.transform.position, Quaternion.identity);
	}
}
