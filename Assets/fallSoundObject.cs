using UnityEngine;
using System.Collections;

public class fallSoundObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("destroy", 3.0f);
	}
	
    void destroy()
    {
        Destroy(this.gameObject);
    }
}
