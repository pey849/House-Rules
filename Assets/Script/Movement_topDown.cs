using UnityEngine;
using System.Collections;

/*
 * Controller Settings:
 * Horizontal_P1
 * Neg Button: left
 * Pos Button: right
 * Snap: checked
 * Invert: checked
 * Type: Joystick axis
 * Axis: 4th axis
 * Joy Num: Get motion from all joystick
 * 
 * Vertical_P1
 * Neg Button: down
 * Pos Button: up
 * Snap: checked
 * Invert: checked
 * Type: Joystick axis
 * Axis: Y axis
 * Joy Num: Get motion from all joystick
 */

public class Movement_topDown : MonoBehaviour {

	public float maxSpeed = 5f;
	public float rotSpeed = 20f;
	
	void Start(){

	}
	
	void Update() 
	{
		//Rotate the player
		Quaternion rot = transform.rotation;
		//shove the current z position into a place holder
		float zAxis = rot.eulerAngles.z;

		zAxis += Input.GetAxis ("Horizontal_P1") * rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0,0, zAxis);
		transform.rotation = rot;

		//grab the current position of the x,y,z coordinates
		Vector3 pos = transform.position;

		Vector3 posChange = new Vector3(0, Input.GetAxis("Vertical_P1") * maxSpeed * Time.deltaTime, 0);

		pos += rot * posChange;

		transform.position = pos;
	}
}
