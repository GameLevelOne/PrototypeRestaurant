//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Game2PlayerMovement : MonoBehaviour {
	public float force;

	private Rigidbody2D rb;
	private float forceMult = 10f;

	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		#if UNITY_EDITOR
			if (Input.GetMouseButtonDown(0))
		#elif UNITY_ANDROID
			if (Input.GetTouch(0).phase == TouchPhase.Began)
		#endif
		{
			rb.AddForce (transform.up * force * forceMult);
		}	
	}
}
