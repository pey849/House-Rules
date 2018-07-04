using UnityEngine;
using System.Collections;

public class diceRandom : MonoBehaviour {

    public Sprite s1, s2, s3, s4, s5, s6;

    void Start()
    {
        //assigns a random dice sprite
        int x = Random.Range(1, 6);
        Sprite tempSprite;
        if (x == 1)
            tempSprite = s1;
        else if (x == 2)
            tempSprite = s2;
        else if (x == 3)
            tempSprite = s3;
        else if (x == 4)
            tempSprite = s4;
        else if (x == 5)
            tempSprite = s5;
        else
            tempSprite = s6;
        this.GetComponent<SpriteRenderer>().sprite = tempSprite;
    }
}
