//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Game3PlayerMovement : MonoBehaviour {
	public float moveForce;
	public bool isUpDown;

	private Rigidbody2D rb;
	private int moveType;

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

//	#if UNITY_ANDROID
//	void FixedUpdate () {
//		if (isUpDown) {
//			rb.velocity = new Vector2 (moveType * moveForce, moveType * moveForce);
//		}
//		rb.velocity = new Vector2 (moveType * moveForce, transform.position.y);
//	}

//	#elif UNITY_EDITOR
	void Update () {
		rb.velocity = new Vector2 (moveForce * moveType, Input.GetAxis("Vertical"));
	}
//	#endif

	public void SetMove (int value) {
//		Debug.Log("TES");
		moveType = value;
	}
}
