using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Game_Timer : MonoBehaviour {

	public Text timeRemainingText;
	public float gameTimer;
	public float waitTimer;
	public int lengthRecTimer;
	public int heightRecTimer;
	public int xCoord;
	public int yCoord;
	public GameObject Player1, Player2, Player3, Player4;
	public AudioSource endSound;
	GameObject[] Players;
	List<string> winners;
	WinAndLoadOverWorld winning;
	float winningTime = 0;
	int determineWinnerOnce = 0;

	void Start () {

		winners = new List<string>();
		winning = GetComponent<WinAndLoadOverWorld>();
		Players = new GameObject[] {Player1, Player2, Player3, Player4};
	}

	// Update is called once per frame
	void FixedUpdate () {
//		if (Mathf.Round (gameTimer) > 10) {
			timeRemainingText.text = "Time Remaining: " + Mathf.Round (gameTimer);
//		} 
//		else {
//			timeRemainingText.text = "Time Remaining: ???";
//		}
		if (gameTimer <= 0) {
			gameTimer = 0;
			if(determineWinnerOnce == 0){
				////endSound.enabled = true;
				if(waitTimer <= -3.0){
					determineWinner ();
					determineWinnerOnce++;
				}
			}
		} else {
			gameTimer -= Time.deltaTime;
		}
		waitTimer -= Time.deltaTime;
	}

	void decreaseTimeRemaining(){
		timeRemainingText.text = "Time Remaining: " + gameTimer;
		if (gameTimer <= 0) {
			gameTimer = 0;
			if(determineWinnerOnce == 0){
				determineWinner ();
				determineWinnerOnce++;
			}
		} else {
			gameTimer -= Time.deltaTime;
		}
	}

	public float returnGameTime()
	{
		return gameTimer;
	}

	void determineWinner(){

		//go through each player
		foreach (GameObject player in Players) {
			//If the current "player" we are looking at has their unattach/steal script on, then they didn't get blown up
			if(player.gameObject.GetComponent<Unattach_Bomb>().isActiveAndEnabled){
				//If the current "player" we are looking at time is better than the current winning time
				if(player.gameObject.GetComponent<Player_Timer>().myTime() > winningTime)
				{
					//update new winning time
					winningTime = player.gameObject.GetComponent<Player_Timer>().myTime();
					//clear out all the previous winners since we have a better time
					winners.Clear();
					//add the new current leader
					//Debug.Log("Current Winner is: " + player.gameObject.tag + " with time " + player.gameObject.GetComponent<Player_Timer>().myTime());
					winners.Add(player.gameObject.tag);
                   
				}
				//else the "player" time is the same as the current winning time
				else if(player.gameObject.GetComponent<Player_Timer>().myTime() == winningTime)
				{
					//add to the current winner's list, no need to clear
					//we can techinally have 4 winners but ideally there should be at most 3
					//Debug.Log("Someone tied the leader: " + player.gameObject.tag);
					winners.Add(player.gameObject.tag);
				}
			}
		}
        //return the winner's list
        //Debug.Log("End result "+winners.Count);
        winning.WinMiniGame(winners);
		
	}



}
