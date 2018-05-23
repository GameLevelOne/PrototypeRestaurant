using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3TestPool : MonoBehaviour {
	public GameObject prefab;
	public int poolSize;
	public float boosterRate;
	public Game3PoolManager Game3PoolManager;

	private float timeToFire = 0;

	// Use this for initialization
	void Awake () {
		Game3PoolManager.CreatePool (prefab, poolSize);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > timeToFire) {
			timeToFire = Time.time + 1 / boosterRate;
			Game3PoolManager.ReuseObject (prefab, transform.position, Quaternion.identity);
		}
	}
}
