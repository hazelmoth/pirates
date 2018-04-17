using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBob : MonoBehaviour {

	float normalPosY;
	public float bobStrength = 1;
	public float bobSpeed = 1;

	// Use this for initialization
	void Start () {
		normalPosY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,
			normalPosY + ((float)Mathf.Sin((2 * Mathf.PI * bobSpeed) * Time.time) * bobStrength),
			transform.position.z);
	}
}
