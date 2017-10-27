using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class Road : MonoBehaviour {


	public Road[] arrayRoad;
	public Rigidbody2D bodyRoad;
	public Vector3 positionRoad;
	public bool checkFind;
	public int directRoad;

	void Awake(){
		arrayRoad = new Road[4];
		bodyRoad = GetComponent<Rigidbody2D> ();
		positionRoad = transform.position;
		checkFind = false;
		directRoad = 4;
		//SetDirectRoad ();

	}

	void Start () {
		Debug.Log ("Hello");
		this.name = "Road "+ transform.position.x+" - " +transform.position.y;
		FindRoad();

	//	string dulieu = JsonUtility.ToJson(this);
	//	dulieu = dulieu.Substring (0, dulieu.Length - 1);
	//	Debug.Log ("Du lieu JSON: "+dulieu);
	//	WriteDataToFile (dulieu);
		}

	
	// Update is called once per frame
	void Update () {
		if (!checkFind) {
			FindRoad ();
		/*	for (int i = 0; i < arrayRoad.Length; i++) {
				if (arrayRoad [i] != null) {
					Road r = arrayRoad [i];
					if ((r.directRoad<4)&&!r.arrayRoad [r.directRoad].Equals (this)) {
						this.directRoad = i;
						break;
					}
				}
			}
		*/
			checkFind = false;
		}

	}

	void OnMouseDown(){
		for (int i = 0; i < 4; i++) {
			if (arrayRoad [i] != null)
				Debug.Log (arrayRoad[i].name);
		}
		Debug.Log ("Huong di: "+directRoad);
	}


	public void FindRoad(){
		GameObject obj;
		obj = GameObject.Find ("Road "+(transform.position.x-5)+" - " +transform.position.y);
		if (obj != null)
			arrayRoad [0] = obj.GetComponent<Road> ();
		obj = GameObject.Find ("Road "+(transform.position.x)+" - " +(transform.position.y-5));
		if (obj != null)
			arrayRoad [1] = obj.GetComponent<Road> ();
		obj = GameObject.Find ("Road "+(transform.position.x+5)+" - " +transform.position.y);
		if (obj != null)
			arrayRoad [2] = obj.GetComponent<Road> ();
		obj = GameObject.Find ("Road "+(transform.position.x)+" - " +(transform.position.y+5));
		if (obj != null)
			arrayRoad [3] = obj.GetComponent<Road> ();
	}

	public virtual void SetDirectRoad(){
		this.directRoad = 4;
	}

	public void WriteDataToFile(string jsonString){
		string path = Application.dataPath+"/Resources/level1.json";
		Debug.Log ("Assetpath: "+path);
		File.AppendAllText (path, jsonString);

		UnityEditor.AssetDatabase.Refresh ();
	}
}
