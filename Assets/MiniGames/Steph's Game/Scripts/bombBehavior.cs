using UnityEngine;
using System.Collections;

public class bombBehavior : MonoBehaviour {

    float countDown = 200;
    public Sprite s1, s2;
    public GameObject explosion;
    public GameObject spawnedObject;

    // Use this for initialization
    void Start()
    {
        //repeatedly call blinkRed()
        InvokeRepeating("blinkRed", 1, 0.1F);
    }

    //if there is still time left in the countDown keep changing color
    //else destroy the bomb and everything it's touching (all its children)
    //change color to red when countDown is even, else change to white
    void blinkRed()
    {
        if (countDown >= 0)
        {
            if (countDown % 2 == 0)
                this.GetComponent<SpriteRenderer>().sprite = s1;
            else
                this.GetComponent<SpriteRenderer>().sprite = s2;
            countDown--;
        }
        else
        {
            spawnedObject = GameObject.Instantiate(explosion, transform.position, transform.rotation) as GameObject;
            if (this.gameObject.transform.root != null && this.gameObject.transform.root.gameObject.tag != "Player")
            {
                GameObject temp = this.gameObject.transform.root.gameObject;
                Destroy(temp);
            }
            Destroy(gameObject);          
        }
    }

}


