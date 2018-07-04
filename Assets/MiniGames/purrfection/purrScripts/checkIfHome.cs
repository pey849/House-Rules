using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class checkIfHome : MonoBehaviour {

	public string shape;
	public string player;
	public static List<string> winners;

	public GameObject shapeObject;
	public AudioSource meow;


	void Start()
	{
		winners = new List<string>();
	}

	//a player has touched the inside 
	void OnCollisionEnter2D (Collision2D coll) 
	{
		if (coll.gameObject.tag == shape) 
		{
			print (coll.gameObject.name + " is home.");

			meow.Play();
			shapeObject.GetComponent<animate>().PlayAnimation(shape);


			if (!winners.Contains(player))
			{
				print (coll.gameObject.name + " has been added to the list.");
				winners.Add (player);
			}
		}
	}
}
