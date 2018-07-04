using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class Mobile_Controller : MonoBehaviour {

	private bool isReady = false;
	public GameObject Player1,Player2,Player3,Player4;

	void Start () {
		// register events
		AirConsole.instance.onReady += OnReady;
		AirConsole.instance.onMessage += OnMessage;
		
	}
	
	void OnReady(string code) {
		Debug.Log("Yay!: air console is ready!");
		isReady = true;
	}

	void OnConnect(int device_id) {
		if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0) {
			if (AirConsole.instance.GetControllerDeviceIds().Count >= 1) {
				StartGame();
			} else {
				//Debug.Log("Nope");
			}
		}
	}

	void StartGame() {
		AirConsole.instance.SetActivePlayers (4);
	}
	
	void OnMessage(int from, JToken data) {
				
		//Debug.Log ("From: " + from);
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber(from);
		//Debug.Log ("Active Player: " + active_player);

		if (from == 1) {
			// received movement from player 1
			if((string)data["movementType"] == "jump"){
				Player1.GetComponent<Player>().SetJump();
				//Debug.Log("Jumping " + Time.time);
			}
			else if ((string)data["movementType"] == "leftMove"){
				//Debug.Log("1 is Moving Left " + Time.time);
				Player1.GetComponent<Player>().SetLeft();
			}
			else if ((string)data["movementType"] == "rightMove"){
				//Debug.Log("1 is Moving Right " + Time.time);
				Player1.GetComponent<Player>().SetRight();
			}
            else if ((string)data["movementType"] == "downMove")
            {
                //Debug.Log("1 is Moving Down " + Time.time);
                Player1.GetComponent<Player>().SetDown();
            }
            else if ((string)data["movementType"] == "upMove")
            {
                //Debug.Log("1 is Moving Up " + Time.time);
                Player1.GetComponent<Player>().SetUp();
            }
            else if((string)data["movementType"] == "still"){
				//Debug.Log("1 is Doing Nothing");
				Player1.GetComponent<Player>().SetRest();
			}
			else if((string)data["movementType"] == "specialPressed"){
				//Debug.Log("1 did their special!");
				Player1.GetComponent<Player>().SetSpecial(true);
			}
			else if((string)data["movementType"] == "specialReleased"){
				//Debug.Log("1 finished their special!");
				Player1.GetComponent<Player>().SetSpecial(false);
			}
		}
		
		else if (from == 2) {
			// received movement from player 2
			if((string)data["movementType"] == "jump"){
				Player2.GetComponent<Player>().SetJump();
				//Debug.Log("Jumping " + Time.time);
			}
			else if ((string)data["movementType"] == "leftMove"){
				//Debug.Log("2 is Moving Left " + Time.time);
				Player2.GetComponent<Player>().SetLeft();
			}
			else if ((string)data["movementType"] == "rightMove"){
				//Debug.Log("2 is Moving Right " + Time.time);
				Player2.GetComponent<Player>().SetRight();
			}
            else if ((string)data["movementType"] == "upMove")
            {
                //Debug.Log("2 is Moving Up " + Time.time);
                Player2.GetComponent<Player>().SetUp();
            }
            else if ((string)data["movementType"] == "downMove")
            {
                //Debug.Log("2 is Moving Down " + Time.time);
                Player2.GetComponent<Player>().SetDown();
            }
            else if((string)data["movementType"] == "still"){
				//Debug.Log("2 is Doing Nothing");
				Player2.GetComponent<Player>().SetRest();
			}
			else if((string)data["movementType"] == "specialPressed"){
				//Debug.Log("2 did their special!");
				Player2.GetComponent<Player>().SetSpecial(true);
			}
			else if((string)data["movementType"] == "specialReleased"){
				//Debug.Log("2 finished their special!");
				Player2.GetComponent<Player>().SetSpecial(false);
			}
		}
		
		else if (from == 3) {
			// received movement from player 3
			if((string)data["movementType"] == "jump"){
				Player3.GetComponent<Player>().SetJump();
				//Debug.Log("Jumping " + Time.time);
			}
			else if ((string)data["movementType"] == "leftMove"){
				//Debug.Log("3 is Moving Left " + Time.time);
				Player3.GetComponent<Player>().SetLeft();
			}
			else if ((string)data["movementType"] == "rightMove"){
				//Debug.Log("3 is Moving Right " + Time.time);
				Player3.GetComponent<Player>().SetRight();
			}            
            else if ((string)data["movementType"] == "upMove")
            {
                //Debug.Log("3 is Moving Up " + Time.time);
                Player3.GetComponent<Player>().SetUp();
            }
            else if ((string)data["movementType"] == "downMove")
            {
                //Debug.Log("3 is Moving Down " + Time.time);
                Player3.GetComponent<Player>().SetDown();
            }
            else if((string)data["movementType"] == "still"){
				//Debug.Log("3 is Doing Nothing");
				Player3.GetComponent<Player>().SetRest();
			}
			else if((string)data["movementType"] == "call_made"){
				//Debug.Log("coming from the dPad");
			}
			else if((string)data["movementType"] == "specialPressed"){
				//Debug.Log("3 did their special!");
				Player3.GetComponent<Player>().SetSpecial(true);
			}
			else if((string)data["movementType"] == "specialReleased"){
				//Debug.Log("3 finished their special!");
				Player3.GetComponent<Player>().SetSpecial(false);
			}
		}
		
		else if (from == 4) {
			// received movement from player 4
			if((string)data["movementType"] == "jump"){
				Player4.GetComponent<Player>().SetJump();
				//Debug.Log("4 is Jumping " + Time.time);
			}
			else if ((string)data["movementType"] == "leftMove"){
				//Debug.Log("4 is Moving Left " + Time.time);
				Player4.GetComponent<Player>().SetLeft();
			}
			else if ((string)data["movementType"] == "rightMove"){
				//Debug.Log("4 is Moving Right " + Time.time);
				Player4.GetComponent<Player>().SetRight();
			}
            else if ((string)data["movementType"] == "upMove")
            {
                //Debug.Log("4 is Moving Up " + Time.time);
                Player4.GetComponent<Player>().SetUp();
            }
            else if ((string)data["movementType"] == "downMove")
            {
                //Debug.Log("4 is Moving Down " + Time.time);
                Player4.GetComponent<Player>().SetDown();
            }
            else if((string)data["movementType"] == "still"){
				//Debug.Log("4 is Doing Nothing");
				Player4.GetComponent<Player>().SetRest();
			}
			else if((string)data["movementType"] == "specialPressed"){
				//Debug.Log("4 did their special!");
				Player4.GetComponent<Player>().SetSpecial(true);
			}
			else if((string)data["movementType"] == "specialReleased"){
				//Debug.Log("4 finished their special!");
				Player4.GetComponent<Player>().SetSpecial(false);
			}
		}
		
	}
	
	void OnDestroy() {
		
		// unregister events
		if (AirConsole.instance != null) {
			AirConsole.instance.onReady -= OnReady;
			AirConsole.instance.onMessage -= OnMessage;
		}
	}
}
