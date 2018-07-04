using UnityEngine;
using System.Collections;

public class timer : MonoBehaviour {

	public float time;
	float timeRemaining;
	
	void Start()
	{
		timeRemaining = time;
		InvokeRepeating ("decreaseTimeRemaining", 1, 1);
	}
	
	void Update()
	{
		//turns the clock so that it is one revolution no matter what the time is set to
		transform.Rotate (0,0,-(360/time)*Time.deltaTime);

		if (timeRemaining == 0)
		{
			FindWinners();
		}
	}
	
	void decreaseTimeRemaining()
	{
		timeRemaining --;
		print (timeRemaining);
	}

	void FindWinners()
	{
		//winners list will be created in another script
		print (checkIfHome.winners);

		this.GetComponent<WinAndLoadOverWorld> ().WinMiniGame (checkIfHome.winners);
	}
}
