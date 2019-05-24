using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {
	public Rigidbody lazer;
	public int playerHealth = 100;

	// Use this for initialization
	void Start () {
		StartCoroutine (shoot ());
	}

	IEnumerator shoot(){
		yield return new WaitForSeconds (2);
		Rigidbody clone;
		clone = Instantiate (lazer, transform.position, transform.rotation);

		clone.velocity = transform.TransformDirection (Vector3.forward * 20);
		Destroy (clone, 20f);
		StartCoroutine (shoot ());
	}
	
	// Update is called once per frame
	void Update () {
		Die ();

		if (Input.GetMouseButtonUp (0)) {

		}
	}

	public void Die(){
		if (playerHealth <= 0) {
			Destroy (gameObject);
		}
	}
}
