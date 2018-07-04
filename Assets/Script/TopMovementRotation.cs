using UnityEngine;
using System.Collections;

public class TopMovementRotation : MonoBehaviour {
    public float speed;
    public float rotationSpeed;
    public float velocity;
    private float moveVertical;
    private float moveHorizontal;

    public bool canMove;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<Player>().GetDown() && canMove)
        {
            if (moveVertical > -1)
                moveVertical -= velocity;
        }
        else if (GetComponent<Player>().GetUp() && canMove)
        {
            if (moveVertical < 1)
                moveVertical += velocity;
        }
        else
            if (moveVertical > 0)
            moveVertical -= velocity;
        else if (moveVertical < 0)
            moveVertical += velocity;

        if (GetComponent<Player>().GetLeft())
        {
            if (moveHorizontal > -1)
                moveHorizontal -= velocity;
        }
        else if (GetComponent<Player>().GetRight())
        {
            if (moveHorizontal < 1)
                moveHorizontal += velocity;
        }
        else
            if (moveHorizontal > 0)
            moveHorizontal -= velocity;
        else if (moveHorizontal < 0)
            moveHorizontal += velocity;

        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;

        z -= moveHorizontal * rotationSpeed * Time.deltaTime;

        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        Vector3 pos = transform.position;

        Vector3 vel = new Vector3(0, moveVertical * speed * Time.deltaTime, 0);
        pos += rot * vel;

        transform.position = pos;
    }
}
