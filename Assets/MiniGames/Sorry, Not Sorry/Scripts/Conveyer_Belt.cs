using UnityEngine;
using System.Collections;

public class Conveyer_Belt : MonoBehaviour {

	public float speed;
	public float bombSpeed;
	
	
	void OnCollisionStay2D(Collision2D c)
	{
		if (c.gameObject.tag == "TheBomb") {
			c.rigidbody.AddForce (new Vector2 (bombSpeed, 1));
			c.rigidbody.freezeRotation = true;
		} else {
			c.rigidbody.AddForce(new Vector2(speed, 1));
			c.rigidbody.freezeRotation = true;
		}

	}
}
