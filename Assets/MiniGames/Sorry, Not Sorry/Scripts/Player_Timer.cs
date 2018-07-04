using UnityEngine;
using System.Collections;

public class Player_Timer : MonoBehaviour {

	float currentBombTime = 0;
	public Transform playerPosition;
	public Transform myBack;
	public Game_Timer theGameTimer;
	bool reEnableStealScript = true;
	Renderer myRender;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//dealing with too many collisions that the unattach script doesn't get turned off properly
		fixStealScript ();
		if (!GetComponent<Unattach_Bomb> ().isActiveAndEnabled) {
			currentBombTime += Time.deltaTime;
		}
		if (!GetComponent<Unattach_Bomb> ().isActiveAndEnabled && (theGameTimer.returnGameTime () <= 0.0)) {
			gameObject.SetActive(false); // Disables game object and children recursively
		}
		if (theGameTimer.returnGameTime () < 0.0) {
			gameObject.GetComponent<Basic_Side_Movement>().enabled = false;
		}
	}

	void OnGUI(){
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		GUI.Box (new Rect((pos.x - 70/2), (Screen.height - pos.y - 43), 70, 20), "" + currentBombTime.ToString("0.0"));
		//Debug.Log (pos);
	}

	public float myTime(){
		return currentBombTime;
	}

	void fixStealScript(){
		bool turnBackOn = true;
		foreach(Transform child in myBack){
			if(child.gameObject.tag == "TheBomb"){
				//can't steal
				gameObject.GetComponent<Unattach_Bomb>().enabled = false;
				turnBackOn = false;
				Debug.Log(transform.tag + " has the bomb");
			}
		}
		if (turnBackOn) {
			gameObject.GetComponent<Unattach_Bomb>().enabled = true;
			Debug.Log(transform.tag + " Doesn't have the bomb");
		}
	}
}
