using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

	private float verticalAxis;
	private float horizontalAxis;
	private float maxVelocity = 1000f;
	private float flapsRotationSpeed = 1f;
	Animator animator;
	private bool throttlePressed;
	private bool flapsLeftPressed;
	private bool flapsRightPressed;
	private bool brakePressed;
	private const float PROPELLER_SPEED_MULTIPLIER = 30f;
	private const float ENGINE_FORCE = 50f;

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
		transform.FindChild("propeller").transform.Rotate (0, (transform.up * rigidbody.velocity.magnitude).z, 0);

		throttlePressed = Input.GetAxis("Throttle") == 1;
		brakePressed = Input.GetAxis("Brake") == 1;
		flapsLeftPressed = Input.GetAxis("flapsLeft") == 1;
		flapsRightPressed = Input.GetAxis("flapsRight") == 1;
		Debug.Log ("right:" + flapsRightPressed);
		Debug.Log ("left:" + flapsLeftPressed);

		if (flapsLeftPressed && !flapsRightPressed) 
		{

			transform.Rotate (new Vector3(0, 0, 1) * -flapsRotationSpeed);
		}
		if (flapsRightPressed && !flapsLeftPressed) 
		{
			transform.Rotate (new Vector3(0, 0, 1) * flapsRotationSpeed);
		}



		if (throttlePressed && rigidbody.velocity.magnitude < maxVelocity) {
			rigidbody.AddForce(transform.up * -ENGINE_FORCE); 
		}
		if (brakePressed && rigidbody.velocity.magnitude > 0) {
			rigidbody.AddForce(transform.up * ENGINE_FORCE); 
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
