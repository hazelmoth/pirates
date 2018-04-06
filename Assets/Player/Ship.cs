using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Ship : NetworkBehaviour {

	[SerializeField] private float speed;
	private Rigidbody rigidbody;
	private GameObject parentCollider;

	public bool isTraveling = false;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isTraveling && isServer) {
			transform.Translate (transform.forward * speed * Time.deltaTime);
		}
	}

	public void ParentPlayer (GameObject player) {
		Player.localPlayer.GetComponent<PlayerShipManager> ().ParentPlayer (player, this.gameObject);
	}

	public void UnarentPlayer (GameObject player) {
		Player.localPlayer.GetComponent<PlayerShipManager> ().UnarentPlayer (player);
	}
}
