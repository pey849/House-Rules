using UnityEngine;
using System.Collections;

public class noAnimSideMovement : MonoBehaviour
{
	
	Rigidbody2D r_body;
	
	public float max_speed;
	public float max_jump;
	
	//jump stuff
	bool grounded = true;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	//check all four side for ground
	public Transform groundCheck1;
	public Transform groundCheck2;
	public Transform groundCheck3;
	public Transform groundCheck4;

	Vector2 start_pos = new Vector2(-12, 10);
	float move = 0f;

	bool facing_right = true;
	
	// Use this for initialization
	void Start()
	{
		r_body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update()
	{

		
	}
	
	void FixedUpdate()
	{
		//get spacebar input and jump
		//button goes to name, key to key
		if (grounded && GetComponent<Player>().GetJump() && r_body.velocity.y < 10)
		{
			//jump - add force up
			r_body.AddForce(new Vector2(r_body.velocity.x, max_jump));
		}

		//get left right
		if (GetComponent<Player> ().GetLeft () && move > -max_speed) {
			move -= 0.5f;
		} else if (GetComponent<Player> ().GetRight () && move < max_speed) {
			move += 0.5f; 
		} else if (move > 0) {
			move -= 0.5f;
		} else if (move < 0) {
			move += 0.5f;
		}

		if (GetComponent<Player> ().GetSpecial ()) 
		{
			transform.localRotation = Quaternion.Euler(0, 30, 0);
		}

		//crazy check for every side of box
		grounded = Physics2D.OverlapCircle(groundCheck1.position, groundRadius, whatIsGround);
		if (grounded == false) {
			grounded = Physics2D.OverlapCircle(groundCheck2.position, groundRadius, whatIsGround);
			if (grounded == false) {
				grounded = Physics2D.OverlapCircle(groundCheck3.position, groundRadius, whatIsGround);
				if (grounded == false) {
					grounded = Physics2D.OverlapCircle(groundCheck4.position, groundRadius, whatIsGround);
				}
			}
		}

		
		//add forces for movement
		r_body.velocity = new Vector2(move, r_body.velocity.y);
	}
}
