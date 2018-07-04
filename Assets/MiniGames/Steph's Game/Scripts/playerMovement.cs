using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    Rigidbody2D r_body;
    public float max_speed;
    public float max_jump;
    public BoxCollider2D objectBoxCollider;
    bool holdingSomething = false;
    bool pickUpPutDownKeyHeld = false;
    float timeOfLastSpecial = 0;
    float currentTime = 0;
    public GameObject fallObject;
    
    //jump stuff
    Vector2 start_posLeft = new Vector2(-5, -2);
    Vector2 start_posRight = new Vector2(5, -2);
    float y_min = -6;
    float y_max = 10;
    bool goodToMove = true;


    // Use this for initialization
    void Start()   {
        r_body = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(0, 9, true);
    }

    // Update is called once per frame
    void Update()
    {
        //can't pick up and drop within 0.5 seconds
        currentTime = Time.time;

        //get spacebar input and jump
        //button goes to name, key to key
          if (GetComponent<Player>().GetJump())  {
             //jump - add force up
            r_body.AddForce(new Vector2(0, max_jump));
        }

        //if A button pressed, check if there is an object in reach to pick up 
        //if player is ontop of an object then pick it up (by making a child of the person) & turn off all it's colliders
        //if a player is already holding something, let go of it & turn on all it's colliders

       // if (GetComponent<Player>().GetSpecial() && !pickUpPutDownKeyHeld && (currentTime - timeOfLastSpecial > 0.5)) {
            if (GetComponent<Player>().GetSpecial() && !pickUpPutDownKeyHeld)
            {
                timeOfLastSpecial = currentTime;
            if (!holdingSomething) {
                letGo();
                checkForObjectToPickUp();
            }
            else  {
                holdingSomething = false;
                letGo();
            }
            pickUpPutDownKeyHeld = true;
        }

        //if pick up/put down key not pressed, then allow key presses again
       if (GetComponent<Player>().GetSpecial() == false)
        {
            pickUpPutDownKeyHeld = false;
        }
    }

    void FixedUpdate()
    {
        //get left right
        //float move = Input.GetAxis(horizCtrl);
        float move = 1;

        //add forces for movement
        //if left move negative
        if (GetComponent<Player>().GetLeft())
        {
            r_body.velocity = new Vector2(-move * max_speed, r_body.velocity.y);
        }

        //if left move negative
        if (GetComponent<Player>().GetRight())
        {
            r_body.velocity = new Vector2(move * max_speed, r_body.velocity.y);
        }

        //reset position when fall down hole
        if (((r_body.position.y < y_min) || (r_body.position.y > y_max)) && goodToMove)
        {
            goodToMove = false;
            GameObject temp = GameObject.Instantiate(fallObject, transform.position, transform.rotation) as GameObject;
            Invoke("ResetPosition", 2.0f); 
        }
    }
    
    //Check if person can pick up an object
    //get all the objects person is touching and find the one that is overlapped the most & carry it 
    //if no object to carry then do nothing 
    void checkForObjectToPickUp()
    {
        GameObject carriedObject = null;
        float distance = Mathf.Infinity;
        Collider2D[] possibleObjectsToCarry = Physics2D.OverlapCircleAll(this.objectBoxCollider.transform.position, 1f, 1);
        for (int i = 0; i < possibleObjectsToCarry.Length; i++)
        {
            if ((possibleObjectsToCarry[i].tag == "box") || (possibleObjectsToCarry[i].tag == "stickyObject"))
            {
                float tempDistance = (transform.position - possibleObjectsToCarry[i].transform.position).sqrMagnitude;
                if (tempDistance < distance)
                {
                    carriedObject = possibleObjectsToCarry[i].gameObject;
                    distance = tempDistance;
                }
            }
            if (carriedObject != null)
            {
                //if sticky object remove sticky object's children before picking up 
                if (carriedObject.tag == "stickyObject")
                    foreach (Transform child in carriedObject.transform)
                    {
                        child.parent = null;
                    }

                //to hold something: make it a child of player
                carriedObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, 0);
                carriedObject.transform.parent = gameObject.transform;
                holdingSomething = true;
            }
        }
    }

    void letGo()
    {
        foreach (Transform child in transform)
            if (child.tag == "box" || child.tag == "stickyObject")
            {
                if (child.tag == "stickyObject")
                    foreach (Transform c in child.transform)
                    {
                        c.parent = null;
                    }
                child.parent = null;
            }
    }

    void ResetPosition()
    {
        if (this.name == "player1" || this.name == "player2")
            r_body.position = start_posLeft;
        if (this.name == "player3" || this.name == "player4")
            r_body.position = start_posRight;
        r_body.velocity = Vector2.zero;
        goodToMove = true;
    }
}

