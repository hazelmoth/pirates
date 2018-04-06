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
		GameObject player = ClientScene.FindLocalObject (playerNetId);
		GameObject ship = ClientScene.FindLocalObject (shipId);
		if (player == Player.localPlayer.gameObject) { 						// Only set the parent if you are the player being parented, so the other clients follow the movement of the player and ship seperately to keep it smooth.
			player.transform.SetParent (ship.transform);            // (This sort of defeats the purpose of doing a command and ClientRpc. Oh well.)
		}
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
		GameObject player = ClientScene.FindLocalObject (playerNetId);
		if (player == Player.localPlayer.gameObject) {
			player.transform.parent = null;
		}
	}
}
