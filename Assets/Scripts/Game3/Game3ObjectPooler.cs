//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3ObjectPooler : MonoBehaviour {

	public List<GameObject> pooledObjects;
	public GameObject Game3Rain;
	public Game3GameMaster Game3GameMaster;
	public int poolAmount;

	public static Game3ObjectPooler Instance;

	void Awake () {
		Instance = this;
	}

	void Start () {
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < poolAmount; i++) {
			GameObject obj = Instantiate (Game3Rain);
			//obj.GetComponent<Game3Rain> ().Game3RainHit += Game3GameMaster.PlayerHitGame3Rain;
			obj.SetActive (false);
			pooledObjects.Add (obj);
		}
	}

	public GameObject GetPooledObject () {
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects [i].activeInHierarchy) {
				pooledObjects [i].GetComponent<Game3Rain> ().Game3RainHit += Game3GameMaster.PlayerHitGame3Rain;
				return pooledObjects [i];
			}
		}

		return null;
	}
}
