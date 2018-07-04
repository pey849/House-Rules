using UnityEngine;
using System.Collections;

public class topMovement : MonoBehaviour
{

    Rigidbody2D r_body;

    //start
    Vector2 start_pos = new Vector2(-12, -2);

    //multiplayer stuff
    public string horizCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";

    public float maxSpeed = 5;
    private float moveHorizontal;
    private float moveVertical;

    // Use this for initialization
    void Start()
    {
        r_body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        //anim.SetFloat("vSpeed", Mathf.Abs(moveVertical));
        //anim.SetFloat("hSpeed", Mathf.Abs(moveHorizontal));

        if (GetComponent<Player>().GetLeft())
        {
            if(moveHorizontal > -1)
                moveHorizontal -= 0.1f;
        }
        else if (GetComponent<Player>().GetRight())
        {
            if(moveHorizontal < 1)   
                moveHorizontal += 0.1f;
        }
        else
            if (moveHorizontal > 0)
            moveHorizontal -= 0.1f;
        else if (moveHorizontal < 0)
            moveHorizontal += 0.1f;


        if (GetComponent<Player>().GetDown())
        {
            if (moveVertical > -1)
                moveVertical -= 0.1f;
        }
        else if (GetComponent<Player>().GetUp())
        {
            if (moveVertical < 1)
                moveVertical += 0.1f;
        }
        else
            if (moveVertical > 0)
            moveVertical -= 0.1f;
        else if (moveVertical < 0)
            moveVertical += 0.1f;


        if (GetComponent<Player>().GetJump())
        {
            Debug.Log("Jumping TopMove");
        }
        if (GetComponent<Player>().GetSpecial())
        {
            Debug.Log("Special TopMove");
        }

        


        //add forces for movement
        r_body.velocity = new Vector2(moveHorizontal * maxSpeed, moveVertical * maxSpeed);        
    }

    public void SetMaxSpeed(int speed)
    {
        maxSpeed = speed;
    }
}