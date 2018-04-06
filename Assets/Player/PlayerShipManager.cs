using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShipManager : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ParentPlayer (GameObject player, GameObject ship) {
		CmdParentPlayer (player.GetComponent<NetworkIdentity>().netId, ship.GetComponent<NetworkIdentity>().netId);
	}

	[Command]
	void CmdParentPlayer (NetworkInstanceId playerNetId, NetworkInstanceId shipId) {
		Debug.Log("[SERVER] Command to parent player to a boat has been called");
		RpcParentPlayer (playerNetId, shipId);
	}

	[ClientRpc]
	void RpcParentPlayer (NetworkInstanceId playerNetId, NetworkInstanceId shipId) {
		GameObject player = NetworkServer.FindLocalObject (playerNetId);
		GameObject ship = NetworkServer.FindLocalObject (shipId);
		player.transform.SetParent (ship.transform);
	}

	public void UnarentPlayer (GameObject player) {
		CmdUnparentPlayer (player.GetComponent<NetworkIdentity>().netId);
	}

	[Command]
	void CmdUnparentPlayer (NetworkInstanceId playerNetId) {
		RpcUnparentPlayer (playerNetId);
	}

	[ClientRpc]
	void RpcUnparentPlayer (NetworkInstanceId playerNetId) {
		GameObject player = NetworkServer.FindLocalObject (playerNetId);
		player.transform.parent = null;
	}
}
