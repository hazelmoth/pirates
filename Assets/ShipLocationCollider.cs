using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShipLocationCollider : NetworkBehaviour { // TODO: Make this just relay a message to the ship (so it's not a NetworkBehavious)

	Ship ship;

	// Use this for initialization
	void Start () {
		ship = GetComponentInParent<Ship> ();
		if (ship == null) {
			Debug.LogError ("ShipLocationCollider apparently not childed to a ship");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Port Border") {
			if (!isServer)
				return;
			Port port = collider.GetComponentInParent<Port> ();
			if (port == null) {
				Debug.LogError ("A ship entered a port border that isn't childed to a port!");
				return;
			}
			port.addShip (ship);
		}
	}
}
