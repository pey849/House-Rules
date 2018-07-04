using UnityEngine;
using System.Collections;

public class waitNewGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("LoadNewGame", 15.0f);
	}


	void LoadNewGame () {
		Application.LoadLevel (0);
	}
}
