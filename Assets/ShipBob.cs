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
		transform.rotation = Quaternion.Euler (new Vector3 (0.128f * curve(Mathf.Sin ((2 * Mathf.PI * bobSpeed) * Time.time + Mathf.PI / 2)) * bobStrength * 5 + 0.31f, (float)this.transform.rotation.eulerAngles.y, 0f));
	}

	float curve (float x) {
		return (float)(Mathf.Pow (1f - x, 3f) * -2.3f) + (3f * Mathf.Pow (1f - x, 2f) * x * 1.3f) + (3f * (1f - x) * Mathf.Pow (x, 2f) * 4.86f) + (Mathf.Pow (x, 3f) * 5.3f);
	}
}
