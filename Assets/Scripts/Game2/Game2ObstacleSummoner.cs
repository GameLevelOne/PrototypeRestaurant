//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Game2ObstacleSummoner : MonoBehaviour {
	public GameObject obstacle;
	//public Text textLog;
	public Game2GameMaster gameMaster;
	public float force;

	private float forceMult = 10f;

	void Awake () {
		InvokeRepeating ("SummonObstacle", 1f, 1f);
	}

	void SummonObstacle () {
		Vector3 summonPos = new Vector3 (transform.position.x, Random.Range (-4, 4), transform.position.z);
		GameObject obstacleGO = Instantiate (obstacle, summonPos, Quaternion.identity);

		obstacleGO.GetComponent<Game2EnemyObstacle> ().obstacleHit += gameMaster.PlayerHitObstacle;
		obstacleGO.GetComponent<Game2EnemyObstacle> ().obstacleDodge += gameMaster.PlayerDodgeObstacle;
		//obstacleGO.GetComponent<Game2EnemyObstacle> ().textLog = textLog;
		obstacleGO.GetComponent<Rigidbody2D> ().AddForce (-transform.right * Random.Range (force/2, force*2) * forceMult);
	}
}
