using UnityEngine;
using System.Collections;

public class LoadMiniGame : MonoBehaviour {

    public int GameToLoad;

    //put on object that will load the mini game
    //this.GetComponent<LoadMiniGame>().LoadGame();
    void OnTriggerEnter2D()
    {
        Application.LoadLevel(GameToLoad);
    }
}
