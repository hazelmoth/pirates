using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackEventHandler : MonoBehaviour {

	private EquippedSword sword;

	// Use this for initialization
	void Start () {
		sword = GetComponentInChildren<EquippedSword> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CheckIfColliding () {
		sword = GetComponentInChildren<EquippedSword> ();
		sword.ActivateCollisionCheck ();
	}
}
