using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class devTools : MonoBehaviour {
	public GameObject wall;
	public GameObject cornerWall;
	public GameObject windowedWall;

	public bool wallSelected;
	public bool cornerWallSelected;
	public bool windowedWallSelected;
	public bool rotateToolOn;
	public bool changeMaterialOn;
	public bool objectSelected;

	public int matNo = 0;

	public Renderer materialToChange;

	public Material brick;
	public Material darkBrick;
	public Material wood;
	public Material concrete;

	Ray ray;
	RaycastHit hit;

	public Vector3 vSpawnPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (matNo == 0 && objectSelected) {
			materialToChange.material = brick;
		}		
		if (matNo == 1 && objectSelected) {
			materialToChange.material = darkBrick;
		}		
		if (matNo == 2 && objectSelected) {
			materialToChange.material = concrete;
		}		
		if (matNo == 4 && objectSelected) {
			materialToChange.material = wood;
		}

		Raycasting();
	
		if (Input.GetKeyDown (KeyCode.Y)) {
			changeMaterialOn = false;
			windowedWallSelected = true;
			rotateToolOn = false;
			wallSelected = false;
			cornerWallSelected = false;
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			changeMaterialOn = false;
			rotateToolOn = false;
			wallSelected = true;
			cornerWallSelected = false;
			windowedWallSelected = false;
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			changeMaterialOn = false;
			rotateToolOn = false;
			wallSelected = false;
			cornerWallSelected = true;
			windowedWallSelected = false;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			rotateToolOn = false;
			wallSelected = false;
			changeMaterialOn = true;
			windowedWallSelected = false;
			cornerWallSelected = false;
		}
		if (Input.GetKeyUp (KeyCode.G) && changeMaterialOn && objectSelected) {
			rotateToolOn = false;
			wallSelected = false;
			changeMaterialOn = true;
			windowedWallSelected = false;
			cornerWallSelected = false;
			if (Input.GetKey (KeyCode.LeftShift)) {
				matNo--;
			} else {
				matNo++;
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			rotateToolOn = true;
			wallSelected = false;
			cornerWallSelected = false;
			windowedWallSelected = false;
			changeMaterialOn = false;

			if (GameObject.Find("rotL") != null && GameObject.Find("rotR") != null)
			{
				GameObject rotL = GameObject.Find ("rotL");
				rotL.SetActive (false);
				GameObject rotR = GameObject.Find ("rotR");
				rotR.SetActive (false);			}
		}
	}

	void Raycasting(){
		if (Input.GetMouseButtonUp (0)) {
			Camera cam = GetComponent<Camera> ();
			ray = cam.ViewportPointToRay (new Vector3 (.5f, 0.5f, 0));
			if (Physics.Raycast (ray, out hit, 100f)) {
				if(wallSelected && hit.transform.tag == "snapPos"){
					vSpawnPos = hit.transform.parent.localPosition;
					vSpawnPos.z += 3;
					vSpawnPos.y = 0;
					vSpawnPos.x = 6.3392f;
					GameObject wallClone = Instantiate (wall, vSpawnPos, hit.transform.localRotation);
					wallClone.transform.parent = hit.transform.parent;
					wallClone.transform.SetAsFirstSibling();
					Destroy (hit.transform.gameObject);
				}else if(wallSelected && hit.transform.tag == "snapPosL"){
					vSpawnPos = hit.transform.parent.localPosition;
					vSpawnPos.z -= 3;
					vSpawnPos.y = 0;
					vSpawnPos.x = 6.3392f;
					GameObject wallClone = Instantiate (wall, vSpawnPos, hit.transform.localRotation);
					wallClone.transform.parent = hit.transform.parent;
					wallClone.transform.SetAsFirstSibling();
					Destroy (hit.transform.gameObject);
				}

				if(wallSelected && hit.transform.tag == "snapCornerL"){
					vSpawnPos = hit.transform.parent.localPosition;
					vSpawnPos.z -= 2.5f;
					//vSpawnPos.y = 0;
					//vSpawnPos.x = 0;
					GameObject wallClone = Instantiate (wall, vSpawnPos, hit.transform.localRotation);
					wallClone.transform.parent = hit.transform.parent;
					wallClone.transform.SetAsFirstSibling();
					Destroy (hit.transform.gameObject);
				}else if(wallSelected && hit.transform.tag == "snapCornerR"){
					vSpawnPos = hit.transform.parent.localPosition;
					vSpawnPos.z += 3;
					//vSpawnPos.y = 0;
					vSpawnPos.x -= 2.5f;
					GameObject wallClone = Instantiate (wall, vSpawnPos, hit.transform.localRotation);
					wallClone.transform.parent = hit.transform.parent;
					wallClone.transform.SetAsFirstSibling();
					Destroy (hit.transform.gameObject);
				}

				else if(cornerWallSelected && hit.transform.tag == "snapPos"){
					GameObject cornerWallClone = Instantiate (cornerWall, hit.transform.position, hit.transform.rotation);
					Destroy (hit.transform.gameObject);
				}else if(windowedWallSelected && hit.transform.tag == "snapPos"){
					GameObject cornerWallClone = Instantiate (windowedWall, hit.transform.position, hit.transform.rotation);
					Destroy (hit.transform.gameObject);
				}

				if (hit.transform.tag == "rotL") {
					hit.transform.parent.parent.Rotate (0f, 0, 90);
				}else if (hit.transform.tag == "rotR") {
					hit.transform.parent.parent.Rotate (0f, 0, -90);
				}

				if (rotateToolOn) {
					Debug.Log (hit.transform.name);
					hit.collider.transform.Find ("rotL").gameObject.SetActive (true);
					hit.transform.Find ("rotR").gameObject.SetActive (true);
				}
				if (changeMaterialOn) {
					Debug.Log (hit.transform.name);
					materialToChange = hit.transform.GetComponent<Renderer>();
					//Material tempMat = tempRend.GetComponent<Material>();
					//materialToChange.material = tempMat;
					objectSelected = true;
				}
			}
		}
	}

	public void selectWall(){
		rotateToolOn = false;
		wallSelected = true;
		cornerWallSelected = false;
	}
	public void selectCornerWall(){
		rotateToolOn = false;
		wallSelected = false;
		cornerWallSelected = true;
	}
	public void selectWindowedWall(){
		rotateToolOn = false;
		wallSelected = false;
		cornerWallSelected = false;
		windowedWallSelected = true;
	}
	public void useRotateTool(){
		wallSelected = false;
		cornerWallSelected = false;
		rotateToolOn = true;
		GameObject rotL = GameObject.Find ("rotL");
		rotL.SetActive (false);
		GameObject rotR = GameObject.Find ("rotR");
		rotR.SetActive (false);
	}
}
