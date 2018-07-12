using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRaycastPoint : MonoBehaviour {

	const float rayCastDistance = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool CheckForObstacles () {
		bool straight =  Physics.Raycast (this.transform.position, this.transform.forward, rayCastDistance, ~(1<<4), QueryTriggerInteraction.Ignore);
		bool down =  Physics.Raycast (this.transform.position, transform.TransformDirection(0f, 1f, 1f).normalized, rayCastDistance, ~(4<<8), QueryTriggerInteraction.Ignore);
		bool up =  Physics.Raycast (this.transform.position, transform.TransformDirection(0f, -1f, 1f).normalized, rayCastDistance, ~(4<<8), QueryTriggerInteraction.Ignore);
		Debug.DrawRay (this.transform.position, this.transform.forward, Color.red, 0.1f);
		Debug.DrawRay (this.transform.position, transform.TransformDirection(0f, 1f, 1f).normalized, Color.red, 0.1f);
		Debug.DrawRay (this.transform.position, transform.TransformDirection(0f, -1f, 1f).normalized, Color.red, 0.1f);
		return straight || down || up;
	}
}
