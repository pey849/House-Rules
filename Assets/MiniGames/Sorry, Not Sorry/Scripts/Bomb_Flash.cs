using UnityEngine;
using System.Collections;

public class Bomb_Flash : MonoBehaviour {

	float countDown = 200;
	public Sprite s1, s2, s3, s4, s5, s6;
	public GameObject explosion;
	public GameObject spawnedObject;
	public Game_Timer theGameTimer;
	
	// Use this for initialization
	void Start()
	{
		//repeatedly call blinkRed()
		InvokeRepeating("blinkRed", 1, 0.1F);
	}
	
	//if there is still time left in the countDown keep changing color
	//else destroy the bomb and everything it's touching (all its children)
	//change color to red when countDown is even, else change to white
	void blinkRed()
	{

		if (theGameTimer.returnGameTime() > 50.0f)
			this.GetComponent<SpriteRenderer>().sprite = s1;
		else if (theGameTimer.returnGameTime() > 40.0f)
			this.GetComponent<SpriteRenderer>().sprite = s2;
		else if (theGameTimer.returnGameTime() > 30.0f)
			this.GetComponent<SpriteRenderer>().sprite = s3;
		else if (theGameTimer.returnGameTime() > 20.0f)
			this.GetComponent<SpriteRenderer>().sprite = s4;
		else if (theGameTimer.returnGameTime() > 10.0f)
			this.GetComponent<SpriteRenderer>().sprite = s5;
		else if (theGameTimer.returnGameTime() > 0.1f)
			this.GetComponent<SpriteRenderer>().sprite = s6;
		else if (theGameTimer.returnGameTime() <= 0.0f)
		{
			spawnedObject = GameObject.Instantiate(explosion, transform.position, transform.rotation) as GameObject;
			Destroy(gameObject);          
		}
	}

}
