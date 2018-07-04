using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class winnerScreen : MonoBehaviour {
    public Text winnerText;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject tumbleweed;
    public AudioSource aweSound, hurraySound;

    // Use this for initialization
    //public void DisplayWinners(List<string> winners)
    void Start()
    {
        bool isWinner = false;
        //make the winner visible if have won according to player prefs
        if (PlayerPrefs.GetInt("Player1winner") == 1) {
            player1.SetActive(true);
            isWinner = true;
        }

        if (PlayerPrefs.GetInt("Player2winner") == 1)
        {
            player2.SetActive(true);
            isWinner = true;
        }
        if (PlayerPrefs.GetInt("Player3winner") == 1)
        {
            player3.SetActive(true);
            isWinner = true;
        }
        if (PlayerPrefs.GetInt("Player4winner") == 1)
        {
            player4.SetActive(true);
            isWinner = true;
        }

        if (!isWinner)
        {
            tumbleweed.SetActive(true);
            aweSound.Play();
        }
        else
            hurraySound.Play();
                
        Invoke("loadOverWorld", 4.0f);
    }

    void loadOverWorld()
    {
        Application.LoadLevel(1);
    }

    
}

