using UnityEngine;
using System.Collections;

public class loadWinner : MonoBehaviour {
    public Sprite c1, c2, c3, c4, d1, d2, d3, d4, h1, h2, h3, h4;

    // Use this for initialization
    void Start()
    {
        int loserCount = 0;
        //set the winner to the big character and all the loser to the small characters
        if (PlayerPrefs.GetInt("Player1winner") == 1)
            setWinner(d1, h1, c1);
        else
            loserCount = addLoser(loserCount, d1, c1);

        if (PlayerPrefs.GetInt("Player2winner") == 1)
            setWinner(d2, h2, c2);
        else
            loserCount = addLoser(loserCount, d2, c2);

        if (PlayerPrefs.GetInt("Player3winner") == 1)
            setWinner(d3, h3, c3);
        else
            loserCount = addLoser(loserCount, d3, c3);

        if (PlayerPrefs.GetInt("Player4winner") == 1)
            setWinner(d4, h4, c4);
        else
            loserCount = addLoser(loserCount, d4, c4);
    }

    int addLoser(int numOfLosers, Sprite dice, Sprite candy)
    {
        if (numOfLosers == 0)
        {
            GameObject.Find("diceL1").GetComponent<SpriteRenderer>().sprite = dice;
            GameObject.Find("candyL1").GetComponent<SpriteRenderer>().sprite = candy;
        }
        else if (numOfLosers == 1)
        {
            GameObject.Find("diceL2").GetComponent<SpriteRenderer>().sprite = dice;
            GameObject.Find("candyL2").GetComponent<SpriteRenderer>().sprite = candy;
        }
        else
        {
            GameObject.Find("diceL3").GetComponent<SpriteRenderer>().sprite = dice;
            GameObject.Find("candyL3").GetComponent<SpriteRenderer>().sprite = candy;
        }
        return numOfLosers + 1;
    }

    void setWinner(Sprite dice, Sprite hat, Sprite candy)
    {
        GameObject.Find("diceWin").GetComponent<SpriteRenderer>().sprite = dice;
        GameObject.Find("candyWin").GetComponent<SpriteRenderer>().sprite = candy;
        GameObject.Find("hat").GetComponent<SpriteRenderer>().sprite = hat;
    }
}
