using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bumpOut : MonoBehaviour {

	public GameObject platformArea;
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public AudioSource angryCat;
	public float xForce;
	public float yForce;

	void OnTriggerEnter2D (Collider2D coll)
	{
		print ("trigger");
		List<GameObject> players = new List<GameObject>();
		players.Add (player1);
		players.Add (player2);
		players.Add (player3);
		players.Add (player4);

		foreach (GameObject player in players) 
		{
			print ("checking if there is someone there");
			if (platformArea.GetComponent<BoxCollider2D> ().bounds.Contains(player.GetComponent<Transform>().position)) 
			{
				print ("There is a player in the bounding box");
				angryCat.Play();
				player.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, yForce));
			}
		}
	}
}
