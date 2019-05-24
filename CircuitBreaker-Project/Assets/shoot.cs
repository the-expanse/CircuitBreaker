using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class shoot : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	public GameObject enemy;
	GameObject particle1;
	GameObject particle2;
	GameObject particle3;
	GameObject deathPS;
	Transform pool;
	GameObject[] spawns;
	Text scoreText;

	public static int score = 0;

	AudioSource audio;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find ("scoreTxt").GetComponent<Text>();
		spawns = GameObject.FindGameObjectsWithTag ("spawnPoint");
		deathPS = GameObject.Find("psDeath");
		shootRaycast ();
		pool = GameObject.Find ("enemyPool").transform;
	}
	
	// Update is called once per frame
	void Update () {
		shootRaycast ();
	}

	void shootRaycast(){
		if(Input.GetMouseButtonDown(0)){
			Debug.Log ("shoot");
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if(Physics.Raycast(ray,out hit, 100)){
				//Particle
				Debug.Log("shoot");
				if(hit.transform.name == "enemy"){
					score += 20;
					scoreText.text = score.ToString ();
					audio = deathPS.GetComponent<AudioSource>();
					int pointNo = (Random.Range (1, 6));
					//Destroy(hit.transform.gameObject);
					particle1 = GameObject.Find("psHip");
					particle2 = GameObject.Find("psHead");
					particle3 = GameObject.Find("psChest");
					audio.Play ();
					deathPS.transform.position = hit.transform.position;
					hit.transform.position = spawns [pointNo].transform.position;
					ParticleSystem ps = particle1.GetComponent<ParticleSystem> ();
					ParticleSystem ps2 = particle2.GetComponent<ParticleSystem> ();
					ParticleSystem ps3 = particle3.GetComponent<ParticleSystem> ();
					ps.Play ();
					ps2.Play ();
					ps3.Play ();
					Debug.Log ("play");
				}
			}
		}
	}
}
