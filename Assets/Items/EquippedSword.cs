using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EquippedSword : NetworkBehaviour {

	private bool isCheckingForCollision = false;
	[SerializeField] private GameObject swordPrefab;
	private Sword sword;

	// Use this for initialization
	void Start () {
		sword = swordPrefab.GetComponent<Sword> ();
	}

	public void ActivateCollisionCheck() {
		isCheckingForCollision = true;
		CancelInvoke ();
		Invoke ("CancelCollisionCheck", 0.2f);
	}

	void OnTriggerStay(Collider collider) {
		if (isCheckingForCollision && collider.GetComponent<Player>() != null && isServer) {
			isCheckingForCollision = false;
			Debug.Log ("A sword hit a player!");
			collider.GetComponent<PlayerHealth> ().TakeDamage (sword.BaseDamage());
		}
	}

	void CancelCollisionCheck () {
		isCheckingForCollision = false;
	}
}
