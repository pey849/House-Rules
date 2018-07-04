using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	public Text player1;
	public Text player2;
	public Text player3;
	public Text player4;


	// Use this for initialization
	void Start () 
	{
		player1.text = PlayerPrefs.GetInt ("Player1Score").ToString();	
		player2.text = PlayerPrefs.GetInt ("Player2Score").ToString();
		player3.text = PlayerPrefs.GetInt ("Player3Score").ToString();
		player4.text = PlayerPrefs.GetInt ("Player4Score").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
