using UnityEngine;
using System.Collections;

public class Rotate_Platform : MonoBehaviour {


	bool canRotate = true;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Quaternion rot = transform.rotation;
		//shove the current z position into a place holder
		float zAxis = rot.eulerAngles.z;
		
		if (zAxis >= 90.0) {
			//Debug.Log("turning off");
			gameObject.GetComponent<PlatformEffector2D> ().enabled = false;
		} else {
			gameObject.GetComponent<PlatformEffector2D> ().enabled = true;
		}
	}
	
	void OnCollisionExit2D (Collision2D coll){
		if (coll.gameObject.tag == "Player1" || coll.gameObject.tag == "Player2"
		    || coll.gameObject.tag == "Player3" || coll.gameObject.tag == "Player4") {
			//Debug.Log("Collided");
			if(canRotate){
				Quaternion rot = transform.rotation;
				//shove the current z position into a place holder
				float zAxis = rot.eulerAngles.z;
				if(zAxis >= 90.0f){
					zAxis = 0.0f;
				}else{
					zAxis = 90.0f;
				}
				rot = Quaternion.Euler (0, 0, zAxis);
				transform.rotation = rot;
				canRotate = false;
				//Debug.Log("Rotate is false");
				StartCoroutine (waitTime());
			}
		}
	}
	
	IEnumerator waitTime(){
		yield return new WaitForSeconds (5.0f);
		//Debug.Log("Rotate is true");
		canRotate = true;
	}

}
