//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Game3RainSpawner : MonoBehaviour {

	public float timeBetweenSpawn, minPosX, maxPosX;

	private Game3ObjectPooler Game3ObjectPooler;
	private float timeSinceLastSpawn;

	void Start () {
		Game3ObjectPooler = Game3ObjectPooler.Instance;
	}

	void FixedUpdate () {
		timeSinceLastSpawn += Time.deltaTime;

		if (timeSinceLastSpawn < timeBetweenSpawn) {
			return;
		} else {
			timeSinceLastSpawn -= timeBetweenSpawn;

			GameObject Game3Rain = Game3ObjectPooler.GetPooledObject ();

			if (Game3Rain != null) {
				Vector3 pos = new Vector3 (Random.Range(minPosX,maxPosX), transform.position.y, transform.position.z);

				Game3Rain.transform.position = pos;
				Game3Rain.transform.rotation = transform.rotation;
				Game3Rain.SetActive (true);
			}
		}
	}
}
