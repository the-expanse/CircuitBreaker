using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hands : MonoBehaviour {
	public GameObject sphere;
	public GameObject lcontroller;
	public GameObject Lwrist;
	//public GameObject Rwrist;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		sphere.transform.position = lcontroller.transform.position;
		Lwrist.transform.position = sphere.transform.position;
		//Lwrist.transform.rotation = Lcontroller.transform.rotation;
		//Rwrist.transform.position = Rcontroller.transform.position;
		//Rwrist.transform.rotation = Rcontroller.transform.rotation;
	}
}
