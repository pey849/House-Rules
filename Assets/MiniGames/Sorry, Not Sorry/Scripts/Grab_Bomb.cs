using UnityEngine;
using System.Collections;

//A class to detect if we can grab the bomb and then called the Attach_Bomb Script

public class Grab_Bomb : MonoBehaviour {

	//all the know player's backs
	public Transform redBack;
	public Transform blueBack;
	public Transform greenBack;
	public Transform yellowBack;
	
	//variable to Bomb_State's getters and setters
	public Bomb_State checkBombState;
	
	
	// Use this for initialization
	void Start () {
		//Debug.Log (transform.childCount);
	}
	
	// Update is called once per frame
	void Update () {
		
		//we have to continuosly track who has the bomb and update its position
		//accordingly to the right player's back
		if (checkBombState.redHasBomb ()) {
			updateBombPosition (redBack);
		} else if (checkBombState.blueHasBomb ()) {
			updateBombPosition(blueBack);
		} else if (checkBombState.greenHasBomb ()) {
			updateBombPosition(greenBack);
		} else if (checkBombState.yellowHasBomb ()) {
			updateBombPosition(yellowBack);
		}
	}
	
	//helper function to update the bomb's position
	void updateBombPosition(Transform playerBack){
		GameObject tempGameObject = GameObject.FindGameObjectWithTag("TheBomb");
		if (tempGameObject != null) {
			Transform tempTransform = tempGameObject.gameObject.GetComponent<Transform> ();
			//Debug.Log("Position of Back: "+playerBack.position + " Position of Bomb: "+tempTransform.position);
			tempTransform.position = playerBack.position;
			tempTransform.SetParent (playerBack);
			//Debug.Log (transform.tag + "has " +transform.childCount + " children");
		}
	}
	
	//collision detection
	void OnCollisionEnter2D (Collision2D coll)
	{
		//if its not attached to something then its just the beginning of the game
		if (checkBombState.isAttached() == false) 
		{
			//if what we are colliding with is the bomb then check which player we are
			if (coll.gameObject.tag == "TheBomb") {
				//if we are player red, then set that it has been attached and to the red player
				if (transform.tag == "Player1") {
					checkBombState.setRedHasBomb ();
					checkBombState.setAttached ();
					coll.gameObject.GetComponent<Transform> ().SetParent (redBack);
					gameObject.GetComponent<Unattach_Bomb>().enabled = false;
					//Debug.Log("Red has it");
					
					//if we are player blue, then set that it has been attached and to the blue player
				} else if (transform.tag == "Player3") {
					checkBombState.setBlueHasBomb ();
					checkBombState.setAttached ();
					coll.gameObject.GetComponent<Transform> ().SetParent (blueBack);
					gameObject.GetComponent<Unattach_Bomb>().enabled = false;
					//Debug.Log("blue has it");
				}else if (transform.tag == "Player4") {
					checkBombState.setGreenHasBomb ();
					checkBombState.setAttached ();
					coll.gameObject.GetComponent<Transform> ().SetParent (greenBack);
					gameObject.GetComponent<Unattach_Bomb>().enabled = false;
					//Debug.Log("green has it");
				}else if (transform.tag == "Player2") {
					checkBombState.setYellowHasBomb ();
					checkBombState.setAttached ();
					coll.gameObject.GetComponent<Transform> ().SetParent (yellowBack);
					gameObject.GetComponent<Unattach_Bomb>().enabled = false;
					//Debug.Log("yellow has it");
				}else{
					//do nothing;
					//Debug.Log("Nothing interesting here");
				}
				
				//destroy the bomb's rigid body as we don't need its physics
				Destroy (coll.gameObject.GetComponent<Rigidbody2D> ());
				//disable the circle collider as it is not part of the player's body collider
				coll.gameObject.GetComponent<CircleCollider2D>().enabled = false;
			}
		} 
		
		//Debug.Log (transform.tag + "has " +transform.childCount + " children");
	}
}
