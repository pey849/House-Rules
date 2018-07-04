using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
    public GameObject player3;
    public GameObject player4;

	public float minSizeY;
    public float buffer;


	

	// Update is called once per frame
	void Update () {
		SetCameraPos ();
		SetCameraSize ();
	}

	void SetCameraPos() {
		Vector3 middle = (player1.transform.position + player2.transform.position + player3.transform.position + player4.transform.position) * 0.25f;
		
		GetComponent<Camera>().transform.position = new Vector3(
			middle.x,
			middle.y,
			GetComponent<Camera>().transform.position.z
			);
	}

	void SetCameraSize() {
		//horizontal size is based on actual screen ratio
		float minSizeX = minSizeY * Screen.width / Screen.height;
		
		//multiplying by 0.5, because the ortographicSize is actually half the height
		float width = Mathf.Abs((player1.transform.position.x ) + (player2.transform.position.x  ) + (player3.transform.position.x) + (player4.transform.position.x)) * 0.5f;
		float height = Mathf.Abs((player1.transform.position.y ) + (player2.transform.position.y ) + (player3.transform.position.y) + (player4.transform.position.y)) * 0.5f;
		
		//computing the size
		float camSizeX = Mathf.Max(width, minSizeX);
		GetComponent<Camera>().orthographicSize = (Mathf.Max(height,
		                                    camSizeX * Screen.height / Screen.width, minSizeY)+ (buffer));
	}

}
