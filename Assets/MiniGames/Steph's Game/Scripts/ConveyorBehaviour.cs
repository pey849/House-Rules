using UnityEngine;
using System.Collections;

public class ConveyorBehaviour : MonoBehaviour {
    public float speed;


    void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.tag != "Player")
        {
            c.rigidbody.AddForce(new Vector2(speed, 1));
            c.rigidbody.freezeRotation = true;
        }
    }
}
