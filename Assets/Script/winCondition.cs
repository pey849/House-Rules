using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class winCondition : MonoBehaviour {

    public WinAndLoadOverWorld win;

    //put on object that will load the mini game
    //this.GetComponent<LoadMiniGame>().LoadGame();
    void OnTriggerEnter2D()
    {
        List<string> winners = new List<string>();
        winners.Add("Player1");

        this.GetComponent<WinAndLoadOverWorld>().WinMiniGame(winners);
    }
}
