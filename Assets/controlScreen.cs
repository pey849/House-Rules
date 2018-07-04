using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class controlScreen : MonoBehaviour {
    public int miniGame;
    bool canPress = false;
    public GameObject p1, p2, p3, p4;
    bool p1Ready = false;
    bool p2Ready = false;
    bool p3Ready = false;
    bool p4Ready = false;
    public GameObject star1, star2, star3, star4;
    public Text text;

    // Use this for initialization
    void Start () {
        Invoke("allowPresses", 3.0f);
        InvokeRepeating("flashText", 0.5f, 0.5f); 
	}

    void Update()
    {
        if (canPress)
        {
            if (p1.GetComponent<Player>().GetSpecial())
            {
                p1Ready = true;
                star1.SetActive(true);
            }
            if (p2.GetComponent<Player>().GetSpecial())
            {
                p2Ready = true;
                star2.SetActive(true);
            }
            if (p3.GetComponent<Player>().GetSpecial())
            {
                p3Ready = true;
                star3.SetActive(true);
            }
            if (p4.GetComponent<Player>().GetSpecial())
            {
                p4Ready = true;
                star4.SetActive(true);
            }
            
            //if all players ready then start game
            if ((p1Ready && p2Ready && p3Ready && p4Ready) || ((p1.GetComponent<Player>().GetJump())))
                Application.LoadLevel(miniGame);
        }

    }

    void allowPresses()
    {
        canPress = true;
    }

    void flashText()
    {
        if (text.enabled == false)
            text.enabled = true;
        else
            text.enabled = false;
    }
}
