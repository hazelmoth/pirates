using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crew : Object {

	private string shipName;

	private List<Player> members;
	private Player captain;
	private Ship ship;

	public Crew(Player captain, Ship ship) {
		this.captain = captain;
		this.ship = ship;
	}

	public void AddMember(Player player) {
		members.Add (player);
	}
}
