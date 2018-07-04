using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class gameConditions : MonoBehaviour {

    public float timeRemaining;
    public WinAndLoadOverWorld win;
    public Text timeRemainingText, winnersText;
	List<string> winners;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject team1space;
    public GameObject team2space;

    void Start()
    {
		winners = new List<string>();
        InvokeRepeating("decreaseTimeRemaining", 1, 1);
        winnersText.enabled = false;
    }


    void decreaseTimeRemaining()
    {
        timeRemaining = timeRemaining - 1.0f;
        timeRemainingText.text = "Time Remaining: " + timeRemaining;

        if (timeRemaining <= 0 && timeRemaining > -10)
        {
            //freeze player movement and then find winner
            timeRemainingText.enabled = false;
            winnersText.enabled = true;
            winnersText.text = "Hold still!";
            player1.SetActive(false);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
            spawn1.SetActive(false);
            spawn2.SetActive(false);

            Invoke("FindWinners", 3.0f);
        }
    }

    void FindWinners()
    {
        //check all objects and find the tallest one
        float tallestTeam1 = -10.0f;
        float tallestTeam2 = -10.0f;

        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].tag == "stickyObject" || allObjects[i].tag == "box")
            {
                Vector3 tempV = new Vector3(allObjects[i].transform.position.x, allObjects[i].transform.position.y, 0);
                if (team1space.GetComponent<BoxCollider2D>().bounds.Contains(tempV))
                {
                    print(allObjects[i].tag);
                    if (allObjects[i].transform.position.y > tallestTeam1)
                        tallestTeam1 = tempV.y;
                }

                else if (team2space.GetComponent<BoxCollider2D>().bounds.Contains(tempV))
                {
                    print(allObjects[i].tag);
                    if (allObjects[i].transform.position.y > tallestTeam2)
                        tallestTeam2 = tempV.y;
                }
            }
        }

        if (tallestTeam1 == tallestTeam2)
        {
            if (tallestTeam1 != -10.0f)
            {
                winners.Add("Player1");
                winners.Add("Player2");
                winners.Add("Player3");
                winners.Add("Player4");
                print("it's a tie!");
            }     
            else
                print("you all are losers!");
        }
        else if (tallestTeam1 > tallestTeam2)
        {
            winners.Add("Player1");
            winners.Add("Player2");
            print("team1 wins");
        }
        else {
            winners.Add("Player3");
            winners.Add("Player4");
            print("team2 wins");
        }   
        this.GetComponent<WinAndLoadOverWorld>().WinMiniGame(winners);
    }

    void loadOverworld()
    {
        this.GetComponent<WinAndLoadOverWorld>().WinMiniGame(winners);
    }
}

