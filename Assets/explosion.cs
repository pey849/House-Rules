using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
        audio.Play();
        Invoke("Destroy", 0.5f);
	}
	
    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
