//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Game3ManagerScript : MonoBehaviour {

	public static Game3ManagerScript Instance { get; private set; }
	public static int counter { get; private set; }

	// Use this for initialization
	void Start () {
		Instance = this;
	}

//	public void IncremenCounter () {
//		counter++;
//	}
//
//	public void RestartGame () {
//		PlayGamesScript.AddScoreToLeaderboard (GPGSIds.leaderboard_distance, counter);
//		counter = 0;
//	}
}
