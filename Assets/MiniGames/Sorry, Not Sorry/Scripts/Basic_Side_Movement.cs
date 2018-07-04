using UnityEngine;
using System.Collections;

public class Basic_Side_Movement : MonoBehaviour {

	public Transform myBack;

	Rigidbody2D r_body;
	
	public float max_speed;
	public float max_jump;
	
	public bool facing_right = true;
	bool notHoldingDownSpecial = false;
	
	//jump stuff
	bool grounded = true;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	float moveHorizontal = 0.0f;

	public Throw_Axe axeThrow;

	
	// Use this for initialization
	void Start()
	{
		r_body = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update()
	{
		//fixStealScript ();
		//get spacebar input and jump
		//button goes to name, key to key
		if (grounded && GetComponent<Player>().GetJump())
		{
			//jump - add force up
			//Debug.Log("I'm Jumping");
			r_body.AddForce(new Vector2(0, max_jump));
		}

		//Is the special being pressed
		axeThrow.wasShootButtonPressed (GetComponent<Player>().GetSpecial());
		

		
	}
	
	void FixedUpdate()
	{


		if (GetComponent<Player> ().GetLeft ()) {
			if (moveHorizontal > -1)
				moveHorizontal -= 0.25f;
		} else if (GetComponent<Player> ().GetRight ()) {
			if (moveHorizontal < 1)   
				moveHorizontal += 0.25f;
		} else
			if (moveHorizontal > 0) {
			moveHorizontal -= 0.25f;
		} else if (moveHorizontal < 0) {
			moveHorizontal += 0.25f;
		}

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
				
		//add forces for movement
		r_body.velocity = new Vector2(moveHorizontal * max_speed, r_body.velocity.y);
		
		if (GetComponent<Player> ().GetRight () && !facing_right) {
			Flip ();
			//Debug.Log("I'm facing right!");
		} else if (GetComponent<Player> ().GetLeft () && facing_right) {
			Flip ();
			//Debug.Log("I'm facing left!");
		} else {
			//do something?
		}

	}
	
	void Flip()
	{
		facing_right = !facing_right;
		Vector3 the_scale = transform.localScale;
		the_scale.x *= -1;
		transform.localScale = the_scale;
	}

	//return the state of whether the character is facing right; Either true of false
	public bool amIFacingRight(){
		return facing_right;
	}
	
}
