using UnityEngine;
using System.Collections;

public class CheckForCubes : MonoBehaviour {

    public int playerNumber;
    private bool done;
    int num = 0;

    void Start()
    {
        done = false;
    }

	public void CheckCubes()
    {
        done = true;        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(done) 
        {            
            if(col.tag == "Cube")
            {                
                num++;
                Destroy(col.gameObject);
                gameObject.GetComponentInParent<GetResults>().Results(playerNumber, num);
            }
            
            
        }
    }
}
