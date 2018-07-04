using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private bool Up;
    private bool Down;
    private bool Left;
    private bool Right;

    private bool Jump;
    private bool Special;


    // Use this for initialization
    void Start () {
        Up = false;
        Down = false;
        Left = false;
        Right = false;

        Jump = Special;
        Special = Jump;
	}

    public void SetUp()
    {
        Up = true;
    }

    public void SetDown()
    {
        Down = true;
    }

    public void SetLeft()
    {
        Left = true;
    }

    public void SetRight()
    {
        Right = true;
    }

    public void SetJump()
    {
        Jump = true;
    }

    public void SetSpecial(bool state)
    {
        Special = state;
    }

    public bool GetUp()
    {
        return Up;
    }

    public bool GetDown()
    {
        return Down;
    }

    public bool GetLeft()
    {
        return Left;
    }

    public bool GetRight()
    {
        return Right;
    }

    public bool GetJump()
    {
        return Jump;
    }

    public bool GetSpecial()
    {
        return Special;
    }


    //while player is at rest set all movement variables to false
    public void SetRest()
    {
        Up = false;
        Down = false;
        Left = false;
        Right = false;
        Jump = false;
    }

}
