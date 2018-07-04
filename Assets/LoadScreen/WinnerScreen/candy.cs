using UnityEngine;
using System.Collections;

public class candy : MonoBehaviour {
    public Sprite s1, s2, s3, s4, s5, s6, s7, s8, s9 , s10, s11, s12, s13, s14, s15, s16;

    // Use this for initialization
    void Start () {

        //assigns a random candy color 
        int x = Random.Range(1, 16);
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
        else if (x == 6)
            tempSprite = s6;
        else if (x == 7)
            tempSprite = s7;
        else if (x == 9)
            tempSprite = s9;
        else if (x == 10)
            tempSprite = s10;
        else if (x == 11)
            tempSprite = s11;
        else if (x == 12)
            tempSprite = s12;
        else if (x == 13)
            tempSprite = s13;
        else if (x == 14)
            tempSprite = s14;
        else if (x == 15)
            tempSprite = s15;
        else 
            tempSprite = s16;
        this.GetComponent<SpriteRenderer>().sprite = tempSprite;
    }

    void Update()
    {
        if (this.transform.position.y < -10)
            Destroy(this);
    }

}
