using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Throw_Axe : MonoBehaviour {

	Rigidbody2D axe;
	public float axeSpeed;
	public string handTag;
	public float rotSpeed;
	public AudioSource sorry;
	bool hasaxe = true;
	bool axeCollided;
	bool shootButtonWasPushed = false;
	bool holdingDownSpecial = false;
	bool facingRight = true;
	public Bomb_State bombState;
	
	public Transform hand;

	public GameObject Player1;

	
	// Use this for initialization
	void Start () {
		axe = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//transform.localScale = new Vector3 (1.554852f,1.222348f,1.0f);
		//Is the button Pressed?
		//Button is pressed
		if (shootButtonWasPressed ()) {

			//Do I have the Axe and not holding down the special button
			//I have the axe and I am not holding down the special button
			if (hasaxe && !holdingDownSpecial) 
			{
				ThrowAxe();
				holdingDownSpecial = true;
				hasaxe = !hasaxe;
			} 
			//I don't have the Axe and I'm not holding down the special button
			else if (!hasaxe && !holdingDownSpecial) {
				RetrieveAxe();
				hasaxe = !hasaxe;
				holdingDownSpecial = true;
			}
			else{
				//do nothing
			}
		}
		//Did I release the special button?
		//The special button was not pressed or was released
		else if (!shootButtonWasPressed ()) {
			//not holding down the special
			holdingDownSpecial = false;
		}

		
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		try
		{
			if (!coll.gameObject.GetComponent<Unattach_Bomb> ().isActiveAndEnabled) {
				//If Blue was active, and collided, then blue steals; set blue has bomb
				if (transform.tag == "Player3") {
					bombState.setBlueHasBomb ();
					
				}
				//else blue was not active and red was, set red has bomb
				else if (transform.tag == "Player1") {
					bombState.setRedHasBomb ();
					
				}
				//else blue,red was not active and green was, set green has bomb
				else if (transform.tag == "Player4") {
					bombState.setGreenHasBomb ();
					
				} else if (transform.tag == "Player2") {
					bombState.setYellowHasBomb ();
					
				}
				//if we collided, then that means an exchange happened
				//call the waittime function to reactivate the unattach/steal script
				//of the previous bomb owner
				sorry.enabled = true;
				StartCoroutine (waitTime (coll));
			}
		}
		catch (Exception e){
			//Debug.Log("Throw Axe Exception");
		}
	}


	public void wasShootButtonPressed(bool state){
		shootButtonWasPushed = state;
	}

	private bool shootButtonWasPressed(){
		return shootButtonWasPushed;
	}

	private void ThrowAxe(){
		gameObject.GetComponent<Return_Axe>().enabled = false;
		
		gameObject.GetComponent<PolygonCollider2D>().enabled = true;
		GameObject.FindGameObjectWithTag(handTag).GetComponent<PolygonCollider2D>().enabled = false;
		//unattach it from the top most parent which is the player body
		// so it doesn't flip (when facing either right or left) 
		transform.parent = null;
		//add some physics to the axe
		gameObject.AddComponent<Rigidbody2D>();
		axe = GetComponent <Rigidbody2D> ();
		
		//axe.constraints = RigidbodyConstraints2D.FreezePositionY;
		axe.gravityScale = 0.01f;
		//shoot axe depending if I am facing right or left
		
		if(Player1.GetComponent<Basic_Side_Movement>().amIFacingRight()){
			//throwing right
			axe.AddForce (axeSpeed*transform.right);
			//Debug.Log("I threw the axe in the right direction");
		}
		else if (!Player1.GetComponent<Basic_Side_Movement>().amIFacingRight()){
			//throw left
			axe.AddForce (axeSpeed*-transform.right);
			//Debug.Log("I threw the axe in the left direction");
		}
			
	}

	private void RetrieveAxe(){
		//call external script to handle the the frame rates of the hammer returning
		gameObject.GetComponent<Return_Axe>().enabled = true;
		//disable the collider, don't want to hit yourself when its coming back
		//possible that we could have it hit people on the way back
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;
		GameObject.FindGameObjectWithTag(handTag).GetComponent<PolygonCollider2D>().enabled = true;

		//set the axe to be back in the parent
		transform.SetParent (hand);
		//destory the rigid body component of the axe. so we don't get those
		//console error messages of a rigid body is already added in the above functions
		Destroy(axe);

		axeCollided = false;
	}



	IEnumerator waitTime(Collision2D coll){
		//Debug.Log(coll.gameObject.tag + " didn't have to wait and is taking the bomb");
		yield return new WaitForSeconds (0.5f);
		sorry.enabled = false;
		coll.gameObject.GetComponent<Unattach_Bomb> ().enabled = true;
		//Debug.Log(coll.gameObject.tag + "'s wait time is over");
	}

}
