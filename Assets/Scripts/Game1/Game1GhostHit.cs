//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Game1GhostHit : MonoBehaviour {

	public delegate void GhostHitEvent(Game1GhostHit obj);
	public event GhostHitEvent GhostClicked;

	public GameObject particleExplode;
	public int ghostScore;
	public SpriteRenderer sprRenderer;
	public bool isSave;

	private Game1GameMaster instanceGM {
		get{ 
			return Game1GameMaster.Instance;
		}
	}

	void Awake () {
		if (!isSave) {
			//Debug.Log (GetComponentInChildren<SpriteRenderer> ().color);
			GetComponentInChildren<SpriteRenderer>().color = Color.red;
		}
	}

	void OnMouseDown () {
//		if (!isSave) {
//			instanceGM.PlayerLose ();
//			return;
//		}

		GameObject explodeGO = Instantiate (particleExplode, transform.position, transform.rotation);
		Destroy (explodeGO, 1f);

//		instanceGM.AddScore (ghostScore);


		if (GhostClicked != null)
			GhostClicked (this);

		Destroy (gameObject);
	}

	void OnDestroy() {
		GhostClicked = null;
	}

}
