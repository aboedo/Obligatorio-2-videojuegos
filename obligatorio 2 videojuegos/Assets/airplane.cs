using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

	private float verticalAxis;
	private float horizontalAxis;
	private float maxVelocity = 1000f;
	Animator animator;
	bool grounded = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		verticalAxis = Input.GetAxis ("Vertical");

		horizontalAxis = Input.GetAxis ("Horizontal");


		transform.Rotate (new Vector3(1, 0, 0) * verticalAxis);
		transform.Rotate (new Vector3(0, 1, 0) * horizontalAxis);
		transform.FindChild("propeller").transform.Rotate (0, 3 * rigidbody.velocity.z, 0);

		bool throttlePressed = Input.GetAxis("Throttle") == 1;
		bool brakePressed = Input.GetAxis("Brake") == 1;


		if (throttlePressed && rigidbody.velocity.magnitude < maxVelocity) {
			rigidbody.AddForce(transform.up * -30); 
		}
		if (brakePressed && rigidbody.velocity.magnitude > 0) {
			rigidbody.AddForce(transform.up * 30); 
		}

	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "ground")
		{
			animator.SetBool("isGrounded", true);
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.name == "ground")
		{
			animator.SetBool("isGrounded", false);
		}
	}
}
