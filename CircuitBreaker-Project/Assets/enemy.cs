using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class enemy : MonoBehaviour {
	NavMeshAgent enemyAgent;
	Transform player;
	public float dist;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("FPSController").transform;
		enemyAgent = this.gameObject.GetComponent<NavMeshAgent> ();
		enemyAgent.destination = player.position;
		StartCoroutine (setDestination ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator setDestination(){
		Animator anim = transform.GetComponent<Animator> ();
		yield return new WaitForSeconds (.2f);
		dist = Vector3.Distance (transform.position, player.position);
		if (dist <= 1.7f) {
			anim.SetBool ("punch", true);
			Debug.Log ("PUNCH");
		}
		enemyAgent.destination = player.position;
		StartCoroutine (setDestination ());
	}
}
