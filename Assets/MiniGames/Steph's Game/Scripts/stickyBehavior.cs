using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class stickyBehavior : MonoBehaviour
{
    public CircleCollider2D myCircleColliderMain;
    public CircleCollider2D myCircleColliderSticky;
    bool hasCollider = true;
    public Sprite s1, s2, s3, s4, s5, s6 ,s7, s8;
    float scaleX, scaleY, scaleZ;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        scaleX = this.GetComponent<Transform>().localScale.x;
        scaleY = this.GetComponent<Transform>().localScale.y;
        scaleZ = this.GetComponent<Transform>().localScale.z;

        //assigns a random candy color 
        int x = Random.Range(1, 8);
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
        else
            tempSprite = s8;
        this.GetComponent<SpriteRenderer>().sprite = tempSprite;
    }


    void Update()
    {
        //if falls off the bottom then Destroy
        if (transform.position.y < -6)
            Destroy(this.gameObject);

        //if it has been picked up by player or attached to a sticky object
        if (this.transform.parent != null)
        {
            if (this.transform.parent.tag == "Player")
            {
                myCircleColliderMain.enabled = false;
                myCircleColliderSticky.enabled = false;
                hasCollider = false;
                Destroy(gameObject.GetComponent<Rigidbody2D>());
                beingMoved();
            }
        }
        else if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            myCircleColliderMain.enabled = true;
            myCircleColliderSticky.enabled = true;
            this.gameObject.AddComponent<Rigidbody2D>();
            hasCollider = true;

            //don't let the scale resize by setting back to original scale
            this.GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
    }

    //when the sticky object touches a box have it stick
    //add the object to the sticky object's children & remove the object's rigidbody2D
    void OnTriggerEnter2D(Collider2D c)
     {
          if (c.gameObject.tag == "box" || c.gameObject.tag == "stickyObject")
          {
              c.transform.parent = gameObject.transform;
              Destroy(c.gameObject.GetComponent<Rigidbody2D>());
              audio.Play();
          }
    }


    //make all child objects no longer children & give them a rigidbody2D
    public void RemoveChildren()
    {
        foreach (Transform child in transform)
        {
            child.parent = null;
            child.gameObject.AddComponent<Rigidbody2D>();
        }
    }

    //turn off colliders
    public void beingMoved()
    {
        myCircleColliderMain.enabled = false;
        myCircleColliderSticky.enabled = false;
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        RemoveChildren();
    }

    //turn on colliders & remove children
    public void setDown()
    {
        myCircleColliderMain.enabled = true;
        myCircleColliderSticky.enabled = true;
    }
}
