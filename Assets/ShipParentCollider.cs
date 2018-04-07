using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParentCollider : MonoBehaviour {

	Ship ship;

	// Use this for initialization
	void Start () {
		ship = GetComponentInParent<Ship> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.GetComponent<Player>() != null) {
			ship.ParentPlayer (collider.gameObject);
		}
	}

	void OnTriggerExit (Collider collider) {
		if (collider.GetComponent<Player>() != null) {
			ship.UnparentPlayer (collider.gameObject);
		}
	}
}
