using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEditor;

public class PortUIManager : NetworkBehaviour {

	[SerializeField] private GameObject portMenu;
	[SerializeField] private GameObject contentPanel;
	[SerializeField] private GameObject listItemPrefab;

	public static PortUIManager instance;

	// Use this for initialization
	void Awake () {
		instance = this;
		Debug.Log ("portuimanager awake");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	struct SerializablePortShipList {
		public string[] shipNames;
		public string[] shipTypes;
		public int[] shipCrewCounts;
		public int[] shipCrewMaxes;
	}

	[Command]
	void CmdRequestShipListForUpdate (NetworkInstanceId portNetId, NetworkInstanceId playerNetId) {
		Port port = NetworkServer.FindLocalObject (portNetId).GetComponent<Port>();
		Player player = NetworkServer.FindLocalObject (playerNetId).GetComponent<Player> ();

		TargetUpdateDockedShipList (player.connectionToClient, ConvertShipListToStruct(port.getDockedShipList()));
	}

	[TargetRpc]
	void TargetUpdateDockedShipList (NetworkConnection target, SerializablePortShipList shipList) {
		for (int i = 0; i < shipList.shipNames.Length; i++) {
			GameObject newListItem = Instantiate (listItemPrefab) as GameObject;
			ShipListItem item = newListItem.GetComponent<ShipListItem> ();
			item.name.text = shipList.shipNames [i];
			item.type.text = shipList.shipTypes [i];
			item.crew.text = "Crew: " + shipList.shipCrewCounts [i] + "/" + shipList.shipCrewMaxes [i];
			newListItem.transform.parent = contentPanel.transform;
			newListItem.transform.localScale = Vector3.one;
		}
	}

	public void EnablePortMenu (Port port) {
		portMenu.SetActive (true);
		CmdRequestShipListForUpdate (port.GetComponent<NetworkIdentity>().netId, Player.localPlayer.GetComponent<NetworkIdentity>().netId);
	}

	public void DisablePortMenu () {
		portMenu.SetActive (false);
	}

	static SerializablePortShipList ConvertShipListToStruct (List<Ship> list) {
		SerializablePortShipList result = new SerializablePortShipList();
		int length = list.Count;
		result.shipNames = new string[length];
		result.shipTypes = new string[length];
		result.shipCrewCounts = new int[length];
		result.shipCrewMaxes = new int[length];
		for (int i = 0; i < length; i++) {
			result.shipNames [i] = list [i].name;
			result.shipTypes [i] = PrefabUtility.GetPrefabParent (list [i].gameObject).name;
			result.shipCrewCounts [i] = 2;
			result.shipCrewMaxes [i] = 3; // Placeholder numbers; TODO: Give ships a max crew number
		}
		return result;
	}
}
