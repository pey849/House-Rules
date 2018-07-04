using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WinAndLoadOverWorld : MonoBehaviour {

    public int OverWorld = 1;
	public int FinalWinner = 7;

    //put on object that has winning condition of game
    //this.GetComponent<LoadOverWorld>().Load(LIST OF PLAYERS WHO WON);
    //by accepting a list, we allow any nuber of winners
    public void WinMiniGame(List<string> winners)
    {
		//set everyone to have not won anything yet
		for (int i = 1; i < 5; i++) 
		{
			PlayerPrefs.SetInt("Player" + i + "winner", 0);
		}

        int pointsToWinGame = PlayerPrefs.GetInt("PointsToWin");

        //list for all the winners of the entire game
        List<string> wonEntireGame = new List<string>();

        //we want the leader to be the player with the lower score if multiple people win
        int otherWinnerScore = pointsToWinGame;

        //go through all the winners - could be any number
        foreach (string winner in winners)
        {
            string player = winner + "Score";
            int oldScore = PlayerPrefs.GetInt(winner + "Score");
            int currentScore = oldScore + 1;

			//add them as a winner for this game to go to the win screen
			PlayerPrefs.SetInt(winner + "winner", 1);

			//increment their score
            PlayerPrefs.SetInt(winner + "Score", currentScore);
           
            if (currentScore == pointsToWinGame)
            {
                wonEntireGame.Add(winner);
            }

            //set this person as the leader if they are the winner with the lowest score
            if (currentScore < otherWinnerScore)
            {
                PlayerPrefs.SetString("Leader", winner);
                //this is the new lowest score
                otherWinnerScore = currentScore;
            }
        }

        //if the list is not empty, the game is over
        if (wonEntireGame.Count > 0)
        {
            //don't care who won the mini-game, so reset all the winners to game winners
			for (int i = 1; i < 5; i++) 
			{
				PlayerPrefs.SetInt("Player" + i + "winner", 0);
			}

			//reset this list to winners of the entire game
			foreach (string winner in wonEntireGame)
			{
				PlayerPrefs.SetInt (winner + "winner", 1);
			}

			//won whole game screen
			Application.LoadLevel (FinalWinner);
        }
        //no one has won yet, so go back to the overworld
        else
        {
            Application.LoadLevel(OverWorld);
        }
    }
}
