using UnityEngine;
using System.Collections;

public class StopPlayer : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            col.GetComponent<Rigidbody2D>().isKinematic = true;
        }
        if(col.tag == "Bullet")
        {
            Destroy(col);
        }
    }
}
