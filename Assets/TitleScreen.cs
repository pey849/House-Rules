using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {

    public LoadNewGame newGame;
    private Player[] playerControls;
    public Text startText;
  

    void Start () {
        playerControls = gameObject.GetComponentsInChildren<Player>();
        InvokeRepeating("flashText", 0.5f, 0.5f);

    }

   void Update () {
        foreach(Player players in playerControls)
        {
            if(players.GetJump() || players.GetSpecial())
            {
                GetComponent<LoadNewGame>().LoadGame();
            }
        }

        
    }

    void flashText()
    {
        if (startText.enabled == false)
            startText.enabled = true;
        else
            startText.enabled = false;
    }

}


