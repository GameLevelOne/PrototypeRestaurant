using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game3PoolObject : MonoBehaviour {
	public float force;

	public virtual void OnObjectReuse () {
		GetComponent<Rigidbody2D> ().velocity = Vector3.up * force;
	}

	protected void Destroy () {
		gameObject.SetActive (false);
	}

	void OnDisable () {
		
	}
}
