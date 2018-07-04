using UnityEngine;
using System.Collections;

public class LoadNewGame : MonoBehaviour {
    public string Player1Score = "Player1Score";
    public string Player2Score = "Player2Score";
    public string Player3Score = "Player3Score";
    public string Player4Score = "Player4Score";

    public string Leader = "Leader";

    public int PointsToWin = 5;

    public int OverWorld = 1;

    //put on object that loads a brand new game state
    //this.GetComponent<LoadNewGame>().LoadGame();
    public void LoadGame()
    {

        PlayerPrefs.SetInt(Player1Score, 0);
        PlayerPrefs.SetInt(Player2Score, 0);
        PlayerPrefs.SetInt(Player3Score, 0);
        PlayerPrefs.SetInt(Player4Score, 0);

        PlayerPrefs.SetInt("PointsToWin", PointsToWin);

        PlayerPrefs.SetString(Leader, "Player1");

        Application.LoadLevel(OverWorld);
    }      
}
