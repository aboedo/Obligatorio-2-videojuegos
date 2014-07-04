using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

	private float verticalAxis;
	private float horizontalAxis;
	private const float MAX_VELOCITY = 1000f;
	private const float FLAPS_ROTATION_TORQUE = 6000f;
	private const float PLANE_ROTATION_TORQUE = 10000f;
	private const float MINIMUM_ROTATION_SPEED = 20f;
	Animator animator;
	private bool throttlePressed;
	private bool flapsLeftPressed;
	private bool flapsRightPressed;
	private bool brakePressed;
	private const float PROPELLER_SPEED_MULTIPLIER = 30f;
	private const float ENGINE_THROTTLE_FORCE = 1000000f;
	private const float ENGINE_STOP_FORCE = 20000f;
	private const float NORMAL_ENGINE_FORCE = 500000f; 

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

		transform.rigidbody.AddTorque (transform.right * verticalAxis * PLANE_ROTATION_TORQUE);
		transform.rigidbody.AddTorque (transform.up * horizontalAxis * PLANE_ROTATION_TORQUE);
		throttlePressed = Input.GetAxis("Throttle") == 1;
		brakePressed = Input.GetAxis("Brake") == 1;
		if (!brakePressed && !grounded) {
			Debug.Log("throttle pressed, add torque to propeller");
			propellerTransform.rigidbody.AddTorque (propellerTransform.transform.up * PROPELLER_SPEED_MULTIPLIER);
			Debug.Log (propellerTransform.transform.up * PROPELLER_SPEED_MULTIPLIER);
		}

		flapsLeftPressed = Input.GetAxis("flapsLeft") == 1;
		flapsRightPressed = Input.GetAxis("flapsRight") == 1;

		if (flapsLeftPressed && !flapsRightPressed) 
		{
			transform.rigidbody.AddTorque (transform.forward * -FLAPS_ROTATION_TORQUE);
		}
		if (flapsRightPressed && !flapsLeftPressed) 
		{
			transform.rigidbody.AddTorque (transform.forward * FLAPS_ROTATION_TORQUE);
		}



		if (throttlePressed && rigidbody.velocity.magnitude < MAX_VELOCITY) {
			rigidbody.AddForce (transform.up * ENGINE_THROTTLE_FORCE * -1); 
		} 
		else if (brakePressed && rigidbody.velocity.y > MINIMUM_ROTATION_SPEED) {
			rigidbody.AddForce (transform.up * ENGINE_STOP_FORCE * -1); 
		} 
		else if (!grounded){
			rigidbody.AddForce (transform.up * NORMAL_ENGINE_FORCE * -1); 
		}

	}
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "ground")
		{
			animator.SetBool("isGrounded", true);
			grounded = true;
		}
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.name == "ground")
		{
			animator.SetBool("isGrounded", false);
			grounded = false;
		}
	}
}
