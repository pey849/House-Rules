using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerFallOff : MonoBehaviour {

    // Use this for initialization
    private bool p1, p2, p3, p4,win;
    private int players = 4;
    private List<string> winner;

    void Start()
    {
        winner = new List<string>();
        winner.Add("Player1");
        winner.Add("Player2");
        winner.Add("Player3");
        winner.Add("Player4");
        win = true;
        p1 = true;
        p2 = true;
        p3 = true;
        p4 = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.name == "Player1" && p1)
        {
            Debug.Log("p1 Lost");
            col.GetComponent<TopMovementRotation>().canMove = false;
            col.GetComponent<AudioSource>().Play();
            col.GetComponent<changeEyes>().swapEye();
            winner.Remove(col.name);
            players -= 1;
            p1 = false;
        }
        if (col.name == "Player2" && p2)
        {
            Debug.Log("p2 Lost");
            col.GetComponent<TopMovementRotation>().canMove = false;
            col.GetComponent<AudioSource>().Play();
            col.GetComponent<changeEyes>().swapEye();
            winner.Remove(col.name);
            players -= 1;
            p2 = false;
        }
        if (col.name == "Player3" && p3)
        {
            Debug.Log("p3 Lost");
            col.GetComponent<TopMovementRotation>().canMove = false;
            col.GetComponent<AudioSource>().Play();
            col.GetComponent<changeEyes>().swapEye();
            winner.Remove(col.name);
            players -= 1;
            p3 = false;
        }
        if (col.name == "Player4" && p4)
        {
            Debug.Log("p4 Lost");
            col.GetComponent<TopMovementRotation>().canMove = false;
            col.GetComponent<AudioSource>().Play();
            col.GetComponent<changeEyes>().swapEye();
            winner.Remove(col.name);
            players -= 1;
            p4 = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {                
        if (players == 1 && win)
        {
            win = false;
            GetComponent<WinAndLoadOverWorld>().WinMiniGame(winner);                           
        }
    }
}
