using UnityEngine;
using System.Collections;

public class Basic_Movement : MonoBehaviour {

	public string horizontalMovement;
	public string verticalMovement;
	public float movementSpeed;
	public float jump_force;
	public string Xbox_Jump_A;

	bool onGround = false;

	//the new game object attached to Player as a child, this gameobject has a circle collider at its feet
	public Transform groundCheck;
	
	//Named a Layer called 'Ground' and attached to platform pieces
	public LayerMask whatIsGround;
	//the ground to feet radius
	private float groundRadius = .1f;

	//rigid body of Player
	Rigidbody2D r_Body;




	// Use this for initialization
	void Start () {
		r_Body = GetComponent<Rigidbody2D> ();
		//onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {

		//If I hit spacebar and I am on the ground, do Jump
		if (Input.GetButton(Xbox_Jump_A)) 
		{
			if(onGround){
				//jump - add force up
				r_Body.AddForce(new Vector2(0.0f,jump_force));
				//print("Jump Force: "+jump_force);
			}
		}

	}

	void FixedUpdate(){

		//check the Ground_Check Transform if we're close to the ground
		//essentially check if we're touching the ground
		onGround = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		//get left/right , a/d
		float h = Input.GetAxis (horizontalMovement);

		//flip the character's x axis if we're going to the left side
		if((Input.GetAxis(horizontalMovement) < 0.0f && transform.localScale.x > 0)||(Input.GetAxis(horizontalMovement) > 0.0f && transform.localScale.x < 0)){
			Vector3 temp = transform.localScale;
			temp.x *= -1.0f;
			transform.localScale = temp;
		}
		
		//add forces for movement
		r_Body.AddForce (new Vector2 (h * movementSpeed, 0));
	}



}
