using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

	private float verticalAxis;
	private float horizontalAxis;
	private float maxVelocity = 1000f;
	private float flapsRotationForce = 1000f;
	private float planeRotationTorque = 10000f;
	private float minimumFlightSpeed = 20;
	Animator animator;
	private bool throttlePressed;
	private bool flapsLeftPressed;
	private bool flapsRightPressed;
	private bool brakePressed;
	private const float PROPELLER_SPEED_MULTIPLIER = 30f;
	private const float ENGINE_FORCE = 1000000f;
	private const float ENGINE_STOP_FORCE = 20000f;

	int propellerMultiplier = 0;
	private Transform propellerTransform;

	bool grounded = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		propellerTransform = transform.FindChild ("propeller");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		verticalAxis = Input.GetAxis ("Vertical");

		horizontalAxis = Input.GetAxis ("Horizontal");

		transform.rigidbody.AddTorque (transform.right * verticalAxis * planeRotationTorque);
		transform.rigidbody.AddTorque (transform.up * horizontalAxis * planeRotationTorque);
		throttlePressed = Input.GetAxis("Throttle") == 1;
		if (throttlePressed) {
			Debug.Log("throttle pressed, add torque to propeller");
			propellerTransform.rigidbody.AddTorque (propellerTransform.transform.up * PROPELLER_SPEED_MULTIPLIER);
			Debug.Log (propellerTransform.transform.up * PROPELLER_SPEED_MULTIPLIER);
		}

		brakePressed = Input.GetAxis("Brake") == 1;
		flapsLeftPressed = Input.GetAxis("flapsLeft") == 1;
		flapsRightPressed = Input.GetAxis("flapsRight") == 1;

		if (flapsLeftPressed && !flapsRightPressed) 
		{
			transform.rigidbody.AddTorque (transform.forward * -flapsRotationForce);
		}
		if (flapsRightPressed && !flapsLeftPressed) 
		{
			transform.rigidbody.AddTorque (transform.forward * flapsRotationForce);
		}



		if (throttlePressed && rigidbody.velocity.magnitude < maxVelocity) {
			rigidbody.AddForce(transform.up * -ENGINE_FORCE); 
		}
		if (brakePressed && rigidbody.velocity.y > minimumFlightSpeed) {
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
