using UnityEngine;
using System.Collections;

public class changeEyes : MonoBehaviour {

	

    public void swapEye()
    {
        foreach(Transform child in transform)
        {
            if (child.tag == "eye")
            {
                child.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (child.tag == "x")
            {
                child.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
