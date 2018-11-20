using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] obj;
	//public Transform target;
	Camera cam;
	// Use this for initialization
	void Start () {
		
		cam = GetComponent<Camera>();
		Spawn();
		InvokeRepeating ("Spawn", 2f, 0.7f);
	}
	
	void Spawn()
	{
		Vector3 viewpos = cam.WorldToViewportPoint(new Vector3());
		Instantiate (obj[Random.Range (0, obj.GetLength(0))], new Vector3(viewpos.x + 5, -4, 0), Quaternion.identity);
	}
}
