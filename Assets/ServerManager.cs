using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerManager : NetworkBehaviour {

	public static ServerManager instance;

	private List<Player> players;
	NetworkManager networkManager;

	// Use this for initialization
	void Start () {
		instance = this;

		players = new List<Player> ();
		networkManager = FindObjectOfType<NetworkManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdatePlayerList() {
		foreach(PlayerController controller in networkManager.client.connection.playerControllers) {
			players.Clear ();
			if (controller.IsValid) {
				players.Add (controller.gameObject.GetComponent<Player>());
			}
		}
	}

	public List<Player> GetPlayerList() {
		return players;
	} 
}
