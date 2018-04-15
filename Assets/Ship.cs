using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Ship : NetworkBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float rotationalSpeed;
	private Rigidbody rigidbody;
	private GameObject parentCollider;
	[SyncVar] private bool wheelIsOccupied = false;

	public bool WheelIsOccupied {get {return wheelIsOccupied;}}
	[SyncVar] public bool isTraveling = false;
	[SyncVar] public bool isRotatingRight = false;
	[SyncVar] public bool isRotatingLeft = false;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isTraveling) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime, transform);
			//rigidbody.AddForce(transform.forward * speed);
			//rigidbody.MovePosition(transform.position + transform.forward * speed);
		}
		if (isRotatingLeft) {
			transform.Rotate (new Vector3 (0f, -rotationalSpeed, 0f));
		}
		else if (isRotatingRight) {
			transform.Rotate (new Vector3 (0f, rotationalSpeed, 0f));
		}
	}

	public void ParentPlayer (GameObject player) {
		Player.localPlayer.GetComponent<PlayerShipManager> ().ParentPlayer (player, this.gameObject);
	}

	public void UnparentPlayer (GameObject player) {
		Player.localPlayer.GetComponent<PlayerShipManager> ().UnparentPlayer (player);
	}

	public void SetWheelOccupied(bool isOccupied) 
	{
		if (!isServer) {
			Debug.LogWarning ("Tried to set isOccupied for ShipWheel from client. Don't do that.");
			return;
		}
		wheelIsOccupied = isOccupied;
	}
}
