using UnityEngine;
using System.Collections;

public class Rotating_Movement : MonoBehaviour {

	Rigidbody2D charController;
	Vector3 moveDirection;
	Vector3 forward;
	Vector3 right;
	
	// Use this for initialization
	void Start () 
	{
		charController = gameObject.GetComponent<Rigidbody2D>();
		right = Vector3.zero;
		forward = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () 
	{
		forward = transform.forward;
		right = new Vector3 (forward.z, 0, -forward.x);

		float horizontalInput = Input.GetAxisRaw("Horizontal_P1");
		float verticalInput = Input.GetAxisRaw("Vertical_P1");

		Vector3 targetDirection = horizontalInput * right + verticalInput * forward;

		moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, 200 * Mathf.Deg2Rad * Time.deltaTime, 1000);

		Vector3 movement = moveDirection * Time.deltaTime * 2;
		charController.AddForce(movement);

		transform.rotation = Quaternion.LookRotation(moveDirection);


		if (targetDirection != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(moveDirection);
		}


	}
	
	//FixedUpdate for control of ship
	void FixedUpdate()
	{

	}
}
