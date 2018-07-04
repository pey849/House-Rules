using UnityEngine;
using System.Collections;
using System;

//This is basically a "Steal Script" not a unattached. 
//This script is enabled only if Player can steal the bomb
//If we have the bomb, then no point of stealing

public class Unattach_Bomb : MonoBehaviour {
	
	public Bomb_State bombState;
	public AudioSource sorry;
	public Transform myBack;
	bool turnTimerOn = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//fixStealScript ();
		//if we have the bomb and we are who we are, disable our "unattach" script
		if (bombState.redHasBomb () && transform.tag == "Player1") {
			//Debug.Log(transform.tag + " is holding the bomb");
			this.enabled = false;
		} else if (bombState.blueHasBomb () && transform.tag == "Player3") {
			this.enabled = false;
			//Debug.Log(transform.tag + " is holding the bomb");
		} else if (bombState.greenHasBomb () && transform.tag == "Player4") {
			this.enabled = false;
			//Debug.Log(transform.tag + " is holding the bomb");
		}else if (bombState.yellowHasBomb () && transform.tag == "Player2") {
			this.enabled = false;
			//Debug.Log(transform.tag + " is holding the bomb");
		}
		
	}
	
	//this collision method is written as a one way collision
	//the only collision it sets off is the one who doesn't have the bomb
	void OnCollisionEnter2D (Collision2D coll)
	{
		try{
			//if our unattach/steal script is active then we can have collision
			if (coll.gameObject.tag != "TheGround" && coll.gameObject.tag != "Untagged") {
				if (this.isActiveAndEnabled && !coll.gameObject.GetComponent<Unattach_Bomb>().isActiveAndEnabled) {
					//If Blue was active, and collided, then blue steals; set blue has bomb
					if (transform.tag == "Player3") {
						bombState.setBlueHasBomb ();

					}
					//else blue was not active and red was, set red has bomb
					else if (transform.tag== "Player1") {
						bombState.setRedHasBomb ();
						
					}
					//else blue,red was not active and green was, set green has bomb
					else if (transform.tag == "Player4") {
						bombState.setGreenHasBomb ();
						
					} 
					else if (transform.tag == "Player2") {
						bombState.setYellowHasBomb ();
						
					}
					//if we collided, then that means an exchange happened
					//call the waittime function to reactivate the unattach/steal script
					//of the previous bomb owner
					sorry.enabled = true;
					StartCoroutine (waitTime (coll));
				}
			}
		}
		catch(Exception e){
			//Debug.Log("Caught Error in Unattach");
		}
	}
	
	IEnumerator waitTime(Collision2D coll){
		//Debug.Log(coll.gameObject.tag + " didn't have to wait and is taking the bomb");
		yield return new WaitForSeconds (0.9f);
		coll.gameObject.GetComponent<Unattach_Bomb> ().enabled = true;
		sorry.enabled = false;
		//Debug.Log(coll.gameObject.tag + "'s wait time is over");
	}

}

