using UnityEngine;
using System.Collections;

public class blockBehaviour : MonoBehaviour {

    BoxCollider2D myBoxCollider;
    bool hasCollider = true;
    public Sprite s1, s2, s3, s4, s5, s6;
    float scaleX, scaleY, scaleZ;

    void Start()
    {
        scaleX = this.GetComponent<Transform>().localScale.x;
        scaleY = this.GetComponent<Transform>().localScale.y;
        scaleZ = this.GetComponent<Transform>().localScale.z;
        myBoxCollider = this.GetComponent<BoxCollider2D>();
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
	
	// Update is called once per frame
	void Update () {
        //if falls off the bottom then Destroy
        if (transform.position.y < -6)
            Destroy(this.gameObject);

        //if it has been picked up by player or attached to a sticky object
        if (this.transform.parent != null)
        {
            if (this.transform.parent.tag == "Player")
            {
                myBoxCollider.enabled = false;
                hasCollider = false;
                Destroy(gameObject.GetComponent<Rigidbody2D>()); 
            }
        }
        else if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            myBoxCollider.enabled = true;
            gameObject.AddComponent<Rigidbody2D>();
            hasCollider = true;

            //don't let the scale resize by setting back to original scale
            this.GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
    }
}
