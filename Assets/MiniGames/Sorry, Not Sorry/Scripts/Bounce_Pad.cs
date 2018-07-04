using UnityEngine;
using System.Collections;

public class Bounce_Pad : MonoBehaviour {

	public float maxBounce;

	void OnCollisionEnter2D (Collision2D coll){
		coll.gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2(0, maxBounce));
		//Debug.Log ("Boumce");
	}

}
