﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider col){
		if (col.name == "AvatarContainer") {
			gun script = col.GetComponentInChildren<gun> ();
			script.playerHealth -= 25;
		}
	}
}
