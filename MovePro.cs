using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MovePro : MonoBehaviour {

	public Rigidbody2D bodyProduct;
	public Road[] arrayNear;
	public bool go = false;
	public bool checkRun;
	public int jGo;
	public Road currentRoad;
	public Road preRoad;
	public bool startCheck;
	public bool doneCreate;
	public float currentLerpTime = 0;
	public float lerpTime = 5;
	public Vector3 startPos;


	void Awake(){
		bodyProduct = GetComponent<Rigidbody2D> ();
		checkRun = true;
		arrayNear = new Road[4];
		startCheck = false;
		doneCreate = false;
		startPos = transform.position;
	}

	void Start () {
		// findNear ();
		for (int i = 0; i < 4; i++) {
			if (arrayNear [i] != null) {
			//	Debug.Log (arrayNear [i].name + " tim thay");
				jGo = i;
				break;
			}
			Debug.Log (transform.position.x+" - "+transform.position.y);
		}
		currentRoad = arrayNear[jGo];



	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			findNear ();
			for (int i = 0; i < 4; i++) {
				if (arrayNear [i] != null) {
				//	Debug.Log (arrayNear [i].name + " tim thay");
					jGo = i;
					break;
				}
				Debug.Log (transform.position.x+" - "+transform.position.y);
			}

			currentRoad = arrayNear[jGo];
			preRoad = currentRoad;
			go = true;
		}
	}

	void FixedUpdate(){
		if (go) {
			if (!transform.position.Equals (currentRoad.transform.position)) {
				//Debug.Log ("Khong bang");
				movePro (currentRoad.transform.position);
			//	Debug.Log (transform.position.x + " - " + transform.position.y);
			} else {
				if (currentRoad.directRoad == 4) {
					for (int i = 0; i < 4; i++) {
						if (currentRoad.arrayRoad [i] != null) {
						//	Debug.Log ("Gom :" + currentRoad.arrayRoad [i].name);
							jGo = i;
							if (!currentRoad.arrayRoad [i].Equals (preRoad)) {
								currentLerpTime = 0;
								startPos = transform.position;
								preRoad = currentRoad;
								currentRoad = currentRoad.arrayRoad [i];
							//	Debug.Log ("Da tim thay " + jGo + " Name: " + currentRoad.name);
								break;	
							}
					
						}
					}
				}
				else {
				//	Debug.Log ("Day roi"+currentRoad.directRoad);
					currentLerpTime = 0;
					startPos = transform.position;
					preRoad = currentRoad;
					currentRoad = currentRoad.arrayRoad [preRoad.directRoad];
				
				}
		
				}


			}
		}
		


	void findNear() {
		GameObject obj;
		obj = GameObject.Find ("Road "+ (transform.position.x-5)+" - " +transform.position.y);

		if (obj != null) {
			Debug.Log (obj.name+" OK");
			arrayNear [0] = obj.GetComponent<Road> ();
		}
		obj = GameObject.Find ("Road "+ (transform.position.x)+" - " +(transform.position.y-5));
		if (obj != null)
			arrayNear [1] = obj.GetComponent<Road> ();
		obj = GameObject.Find ("Road "+ (transform.position.x+5)+" - " +transform.position.y);
		if (obj != null)
			arrayNear [2] = obj.GetComponent<Road> ();
		obj = GameObject.Find ("Road "+ (transform.position.x)+" - " +(transform.position.y+5));
		if (obj != null)
			arrayNear [3] = obj.GetComponent<Road> ();
	}

	void movePro(Vector3 endPos){
		currentLerpTime += Time.deltaTime;
		if (currentLerpTime >= lerpTime) {
			
			currentLerpTime = lerpTime;
		}

		float Perc = 5*currentLerpTime / lerpTime;
		this.transform.position = Vector3.Lerp (startPos,endPos,Perc);
	}





}
	
