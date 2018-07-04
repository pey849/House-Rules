using UnityEngine;
using System.Collections;

public class Return_Axe : MonoBehaviour {

	public Transform endMarker;
	public float playerSpeed;
	
	
	// Update is called once per frame
	void Update () {
		//make hammer move towards the player at (speed of the player/movement script)*delta time
		transform.position = Vector3.MoveTowards (transform.position, endMarker.position, playerSpeed*Time.deltaTime);
		//return hammer back to it original upright position
		transform.rotation = Quaternion.Euler (0,0,0);
		transform.localScale = new Vector3 (1.554852f,1.222348f,1.0f);
	}
}
