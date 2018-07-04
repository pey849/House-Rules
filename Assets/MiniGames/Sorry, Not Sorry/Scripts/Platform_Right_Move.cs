using UnityEngine;
using System.Collections;

public class Platform_Right_Move : MonoBehaviour {

	public float platformXSpeed;
	private Vector3 platformPosition;
	
	// Update is called once per frame
	void Update () {
		
		platformPosition = transform.position;
		//move platform to the left then back to original position
		platformPosition.x += platformXSpeed*Mathf.Sin(Time.time);
		transform.position = platformPosition;
	}
}
