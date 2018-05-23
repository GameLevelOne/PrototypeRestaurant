//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Game3Rain : MonoBehaviour {//, IPooledObject {
	public delegate void Game3RainHitEvent (Game3Rain obj);
	public event Game3RainHitEvent Game3RainHit;

	private Rigidbody2D rb;

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag.Equals ("Boundary")) {
			gameObject.SetActive (false);
		} else if (col.tag.Equals ("Player")) {
			if (Game3RainHit != null) {
				Game3RainHit (this);
			}
		}
	}

	void OnDisable () {
		Game3RainHit = null;
	}
}
