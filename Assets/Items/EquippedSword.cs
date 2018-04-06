using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedSword : MonoBehaviour {

	private bool isCheckingForCollision = false;

	// Use this for initialization
	void Start () {
		
	}

	public void ActivateCollisionCheck() {
		isCheckingForCollision = true;
		CancelInvoke ();
		Invoke ("CancelCollisionCheck", 0.2f);
	}

	void OnTriggerStay(Collider collider) {
		if (isCheckingForCollision && collider.GetComponent<Player>() != null) {
			isCheckingForCollision = false;
			Debug.Log ("A sword hit a player!");
		}
	}

	void CancelCollisionCheck () {
		isCheckingForCollision = false;
	}
}
