using UnityEngine;
using System.Collections;

public class Bomb_State : MonoBehaviour {

	//booleans for who has it attached
	bool redHasBombAttached;
	bool blueHasBombAttached;
	bool greenHasBombAttached;
	bool yellowHasBombAttached;
	
	bool attached;
	
	// Use this for initialization
	void Start () {
		redHasBombAttached = false;
		blueHasBombAttached = false;
		greenHasBombAttached = false;
		yellowHasBombAttached = false;
		attached = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//set blue has the bomb attached
	public void setBlueHasBomb(){
		blueHasBombAttached = true;
		redHasBombAttached = false;
		greenHasBombAttached = false;
		yellowHasBombAttached = false;
	}
	
	//set red has the bomb attached
	public void setRedHasBomb(){
		blueHasBombAttached = false;
		redHasBombAttached = true;
		greenHasBombAttached = false;
		yellowHasBombAttached = false;
	}
	
	public void setGreenHasBomb(){
		greenHasBombAttached = true;
		yellowHasBombAttached = false;
		blueHasBombAttached = false;
		redHasBombAttached = false;
	}
	
	//set red has the bomb attached
	public void setYellowHasBomb(){
		yellowHasBombAttached = true;
		blueHasBombAttached = false;
		redHasBombAttached = false;
		greenHasBombAttached = false;
	}
	
	//set that the bomb is attached to something
	public void setAttached(){
		attached = true;
	}
	
	//is the bomb attached?
	public bool isAttached(){
		return attached;
	}
	
	//red has bomb
	public bool redHasBomb(){
		return redHasBombAttached;
	}
	
	//blue has bomb
	public bool blueHasBomb(){
		return blueHasBombAttached;
	}
	
	//green has bomb
	public bool greenHasBomb(){
		return greenHasBombAttached;
	}
	
	//yellow has bomb
	public bool yellowHasBomb(){
		return yellowHasBombAttached;
	}

}
