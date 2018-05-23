//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Game2EnemyObstacle : MonoBehaviour {
	//public Text textLog;

	public delegate void ObstacleHitEvent(Game2EnemyObstacle obj);
	public event ObstacleHitEvent obstacleHit;
	public event ObstacleHitEvent obstacleDodge;

//	void Start() {
//		Debug.Log ("Enemy Created");
//	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag.Equals ("Player")) {
//			Debug.Log ("Hit Player");
//			textLog.text = "Hit Player";
			if (obstacleHit != null)
				obstacleHit (this);
		} else if (col.tag.Equals ("Score")) {
//			Debug.Log ("Hit Score");
//			textLog.text = "Hit Score";
			if (obstacleDodge != null)
				obstacleDodge (this);
		} else if (col.tag.Equals ("Finish")) {
			Destroy (gameObject);
		}
	}

	void OnDestroy() {
		obstacleHit = null;
		obstacleDodge = null;
	}
}
