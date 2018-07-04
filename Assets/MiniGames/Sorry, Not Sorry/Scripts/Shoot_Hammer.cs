using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Controller Settings:
 * Xbox_Jump_A
 * Neg Button: 
 * Pos Button: joystick button 0
 * Snap: unchecked
 * Invert: unchecked
 * Type: Key or Mouse Button
 * Axis: X axis
 * Joy Num: Get motion from all joystick
 * 
 * Left_Xbox_Trigger
 * Snap: unchecked
 * Invert: unchecked
 * Type: Joystick axis
 * Axis: 9th Axis
 * Joy Num: Get motion from all joystick
 *
 * Right_Xbox_Trigger
 * Snap: unchecked
 * Invert: unchecked
 * Type: Joystick axis
 * Axis: 10th Axis
 * Joy Num: Get motion from all joystick

 */

public class Shoot_Hammer : MonoBehaviour {

	Rigidbody2D Hammer;
	public float hammerSpeed;
	public string hammerTrigger;
	public string returnHammer;
	public string handTag;
	public float rotSpeed;
	bool hasHammer = true;
	bool hammerCollided;

	public Transform hand;

	Return_Hammer callScript;
	public GameObject Player;

	//temporary code
	List<string> winners;
	//temporary win condition
	int hammerReturned = 0;

	WinAndLoadOverWorld winning;

	// Use this for initialization
	void Start () {
		Hammer = GetComponent <Rigidbody2D> ();
		winners = new List<string>();
		winning = GetComponent<WinAndLoadOverWorld>();

	}
	
	// Update is called once per frame
	void Update () {

		//If left trigger is pressed on the xbox controller
		//throw hammer.  If pressed it goes from 0 to 1. 1 for being pressed
		if (Input.GetButtonDown (hammerTrigger) && hasHammer) {

			gameObject.GetComponent<Return_Hammer>().enabled = false;

			gameObject.GetComponent<PolygonCollider2D>().enabled = true;
			GameObject.FindGameObjectWithTag(handTag).GetComponent<PolygonCollider2D>().enabled = false;
			//unattach it from the top most parent which is the player body
			// so it doesn't flip (when facing either right or left) 
			transform.parent = null;
			//add some physics to the hammer
			gameObject.AddComponent<Rigidbody2D>();
			Hammer = GetComponent <Rigidbody2D> ();

			//Hammer.constraints = RigidbodyConstraints2D.FreezePositionY;
			Hammer.gravityScale = 0.5f;
			//shoot hammer depending if I am facing right or left

			if(Player.GetComponent<Basic_Side_Movement>().facing_right){
				Hammer.AddForce (hammerSpeed*transform.right);
			}
			else{
				Hammer.AddForce (hammerSpeed*-transform.right);
			}
			hasHammer = false;
			Debug.Log("I threw the hammer!");
		}

		if(Input.GetButtonDown(returnHammer) && !hasHammer){
			//call external script to handle the the frame rates of the hammer returning
			gameObject.GetComponent<Return_Hammer>().enabled = true;
			//disable the collider, don't want to hit yourself when its coming back
			//possible that we could have it hit people on the way back
			gameObject.GetComponent<PolygonCollider2D>().enabled = false;
			GameObject.FindGameObjectWithTag(handTag).GetComponent<PolygonCollider2D>().enabled = true;
			//techinally has the hammer, could set the condition that it has it
			//once it touches the "Hand" tag
			hasHammer = true;
			//set the hammer to be back in the parent
			transform.SetParent (hand);
			//destory the rigid body component of the hammer. so we don't get those
			//console error messages of a rigid body is already added in the above functions
			Destroy(Hammer);

			//simple win condition
			//winners.Add("Player1");
			//GetComponent<WinAndLoadOverWorld>().WinMiniGame(winners);

			hammerCollided = false;
			Debug.Log("I retreived the hammer!");

			//temp win condition
			hammerReturned++;
		}
		//update on spinning the hammer only if player has no hammer
		//and it hasn't collided with platforms/walls
		if (!hasHammer && !hammerCollided) {
			spinHammer();
		}

//		if (hammerReturned == 2) {
//			//simple win condition
//			winners.Add("Thor");
//
//			winning.WinMiniGame(winners);
//		}
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "TheGround" && !hasHammer) {

			hammerCollided = true;
			//print ("Collided");
		}
	}

	void spinHammer(){
		//Rotate the player
		Quaternion rot = transform.rotation;
		//shove the current z position into a place holder
		float zAxis = rot.eulerAngles.z;
		zAxis += rotSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, zAxis);
		transform.rotation = rot;
	}
}
