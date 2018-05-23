//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Game1GhostSummoner : MonoBehaviour {
	public GameObject ghost;
	public Transform targetPos;
	//public Transform[] summonPos;
	public float maxForce, minForce;
	public float minPosX, maxPosX;

	private float forceMult = 10f;

	public Game1GameMaster gameMaster;

	void Awake () {
		InvokeRepeating ("SummonGhost", 0f, 1f);
	}

	void SummonGhost () {
		//int randomIndex = Mathf.FloorToInt (Random.Range (0, summonPos.Length));

		//Vector3 dirRot = targetPos.position - summonPos[randomIndex].position;
		//float angleRot = Mathf.Atan2 (dirRot.y, dirRot.x) * Mathf.Rad2Deg * -90f;
		//Quaternion targerRot = Quaternion.AngleAxis (angleRot, Vector3.forward);
		//GameObject ghostGO = Instantiate (ghost, summonPos[randomIndex].position, targerRot);

		Vector3 summonPos = new Vector3 (Random.Range (minPosX, maxPosX), transform.position.y, transform.position.z);
		Vector3 dirRot = targetPos.position - summonPos;

		bool[] ghostsSafety = new bool[5]{true, false, false, true, true};
		int randomIndex = Mathf.FloorToInt (Random.Range (0, ghostsSafety.Length));

		GameObject ghostGO = Instantiate (ghost, summonPos, Quaternion.identity);
		ghostGO.GetComponent<Game1GhostHit> ().isSave = ghostsSafety [randomIndex];
		ghostGO.SetActive (true);
		ghostGO.GetComponent<Rigidbody2D> ().AddForce (dirRot * Random.Range(minForce, maxForce) * forceMult);

		ghostGO.GetComponent<Game1GhostHit> ().GhostClicked += Game1GameMaster.Instance.GhostHitByPlayer;

		Destroy (ghostGO, 5f);
	}
}
