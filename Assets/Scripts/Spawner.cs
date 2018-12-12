using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] private float maxSpawn; 
	[SerializeField] private float minSpawn;
	[SerializeField] private GameObject[] obj;
	void Start () {
		StartCoroutine(Spawn()); // Starts coroutine Spawn()
	}
	
	///<summary>
	/// IEnumerator method for spawning objects from array to be used in conjuction with Unity's Coroutine.
	///</summary>
	IEnumerator Spawn()
	{
		//Creating infinite while loop for spawning objects from array
		while (true) {
			yield return new WaitForSeconds(Random.Range(minSpawn,maxSpawn));
			Instantiate (obj[Random.Range (0, obj.GetLength(0))], gameObject.transform.position, Quaternion.identity);
		}
	}
}
