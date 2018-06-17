using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Port : NetworkBehaviour {

	private List<Ship> ships = new List<Ship>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addShip (Ship ship) {
		if (!isServer) {
			Debug.LogError ("Someone who isn't the server tried to interact with a port");
			return;
		}
		ships.Add (ship);
	}

	public void removeShip (Ship ship) {
		if (!isServer) {
			Debug.LogError ("Someone who isn't the server tried to interact with a port");
			return;
		}
		ships.Remove (ship);
	}

	public List<Ship> getDockedShipList() {
		if (!isServer) {
			Debug.LogError ("A client is trying to retrieve a port's ship list");
		}
		return ships;
	}
}
