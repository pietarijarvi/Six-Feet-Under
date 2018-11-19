using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 1f;
	public float spawnMax = 2f;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 2, 1);
	}
	
	void Spawn()
	{
		Instantiate (obj[Random.Range (0, obj.GetLength(0))], new Vector2(0,0), Quaternion.identity);
//		InvokeRepeating ("Spawn", Random.Range (spawnMin, spawnMax));
	}
}
