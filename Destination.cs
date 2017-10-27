using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : Road {




	void OnCollisionEnter2D(Collision2D o){
		Debug.Log ("va cham voi: "+ o.gameObject.name);
		Debug.Log ("va cham");
		Destroy (o.gameObject);

	}
}
