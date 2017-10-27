using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direct : Road {

	public SpriteRenderer avatarDirect;
	public int[] directAvaiable;
	private int j;
	void Awake(){
		arrayRoad = new Road[4];
		bodyRoad = GetComponent<Rigidbody2D> ();
		positionRoad = transform.position;
		checkFind = false;
		base.directRoad = directAvaiable [0];
		avatarDirect = GetComponent<SpriteRenderer> ();
		avatarDirect.sprite = Resources.Load<Sprite> ("") as Sprite;
		setDirectAvatar (directRoad);

	}
		

	void OnMouseDown(){
		j = (j + 1) % directAvaiable.Length;
		base.directRoad = directAvaiable [j];
		setDirectAvatar (directRoad);
			
		Debug.Log ("Mui ten: "+directRoad);

	}

	void setDirectAvatar(int i){

		switch (i) {
		case(0):
			avatarDirect.sprite = Resources.Load<Sprite> ("arrowLeft") as Sprite;
			break;
		case(1):
			avatarDirect.sprite = Resources.Load<Sprite> ("arrowDown") as Sprite;
			break;
		case(2):
			avatarDirect.sprite = Resources.Load<Sprite> ("arrowRight") as Sprite;
			break;
		case(3):
			avatarDirect.sprite = Resources.Load<Sprite> ("arrowUp") as Sprite;
			break;
		}

	}
}
