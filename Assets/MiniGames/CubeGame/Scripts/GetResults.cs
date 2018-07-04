using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetResults : MonoBehaviour {

    int[] playerList;
    List<string> winners;
    string player;
       
    void Start()
    {
        playerList = new int[4];
        winners = new List<string>();
    }

    //takes in player score and inserts them into an array
    //the array is sorted by player number
	public void Results(int player, int score)
    {
        playerList[player] = score;
    }

    public void findWinner()
    {
        //temp variable to hold largerst score among players
        int Smallest = 1000;

        //itterates through all players to find the highest score
        for (int i = 0; i < 4; i++)
        {
            if (Smallest > playerList[i])
            {                
                Smallest = playerList[i];
            }
        }

        //itterates through all players and adds all players 
        //with highest score to a list of winners
        for (int i = 0; i < 4; i++)
        {
            if (Smallest == playerList[i])
            {
                player = "Player" + (i+1).ToString();                              
                winners.Add(player);                
            }                                 
        }        
        gameObject.GetComponent<WinAndLoadOverWorld>().WinMiniGame(winners);
    }
}
