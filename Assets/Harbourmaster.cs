﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harbourmaster : MonoBehaviour {

	[SerializeField] private Port port;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Port GetPort() {
		return port;
	}
}
