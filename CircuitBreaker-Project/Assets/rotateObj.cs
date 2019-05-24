using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObj : MonoBehaviour {
	public float rotSpeed;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseDrag(){
		float rotX = Input.GetAxis ("Mouse X") * rotSpeed * 90f;

		transform.RotateAround (Vector3.up, rotX);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
