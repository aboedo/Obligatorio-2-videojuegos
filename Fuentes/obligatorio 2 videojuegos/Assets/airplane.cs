﻿using UnityEngine;
using System.Collections;


/// ------------------------------------------------------------------------------------------------
/// <summary>
/// Handles all airplane movement and physics
/// </summary>
public class airplane : MonoBehaviour {

	#region constants

	private const float MAX_VELOCITY = 1000f;
	private const float FLAPS_ROTATION_TORQUE = 6000f;
	private const float PLANE_ROTATION_TORQUE = 10000f;
	private const float MINIMUM_ROTATION_SPEED = 20f;
	private const float PROPELLER_SPEED_MULTIPLIER = 30f;
	private const float ENGINE_THROTTLE_FORCE = 1000000f;
	private const float ENGINE_THROTTLE_FORCE_GROUNDED = 800000f;
	private const float ENGINE_STOP_FORCE = 20000f;
	private const float ENGINE_NORMAL_FORCE = 500000f; 

	#endregion


	#region variables

	public bool grounded = false;
	public GameObject shot;
	public Transform shotPosition;
	public float fireRate;
	private float nextFire;
	private Animator animator;
	private float verticalAxis;
	private float horizontalAxis;
	private bool turboPressed;
	private bool throttlePressed;
	private bool flapsLeftPressed;
	private bool flapsRightPressed;
	private bool brakePressed;
	private Transform propellerTransform;
	private racetrack currentRaceTrack;

	#endregion

	public bool isGrounded()
	{
		return grounded;
	}

	public bool isBraking()
	{
		return brakePressed;
	}

	public bool isAccelerating()
	{
		return throttlePressed;
	}
	
	/// ------------------------------------------------------------------------------------------------
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		propellerTransform = transform.FindChild ("propeller");
		currentRaceTrack = GameObject.Find ("RaceTrack").GetComponent<racetrack> ();
	}


	/// ------------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update () {

	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Stores all player input in variables
	/// </summary>
	void GetAllInput(){
		verticalAxis = Input.GetAxis ("Vertical");
		horizontalAxis = Input.GetAxis ("Horizontal");
		throttlePressed = Input.GetAxis("Throttle") == 1;
		brakePressed = Input.GetAxis("Brake") == 1;
		flapsLeftPressed = Input.GetAxis("flapsLeft") == 1;
		flapsRightPressed = Input.GetAxis("flapsRight") == 1;

		turboPressed = Input.GetAxis ("changeLevel") ==1;
	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Rotates the plane according to player input
	/// </summary>
	void RotatePlaneFromInput(){
		transform.rigidbody.AddTorque (transform.right * verticalAxis * PLANE_ROTATION_TORQUE);
		transform.rigidbody.AddTorque (transform.up * horizontalAxis * PLANE_ROTATION_TORQUE);

		if (flapsLeftPressed && !flapsRightPressed) 
		{
			transform.rigidbody.AddTorque (transform.forward * -FLAPS_ROTATION_TORQUE);
		}
		if (flapsRightPressed && !flapsLeftPressed) 
		{
			transform.rigidbody.AddTorque (transform.forward * FLAPS_ROTATION_TORQUE);
		}

	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Adds torque to the propeller if: 
	/// - the throttle is pressed
	/// - the brake is not pressed while in the air
	/// - or the plane is on the ground and the throttle is pressed
	/// </summary>
	void UpdatePropeller(){
		if (throttlePressed || ((!brakePressed && !grounded) || (grounded && throttlePressed))) {
			propellerTransform.rigidbody.AddTorque (propellerTransform.transform.up * PROPELLER_SPEED_MULTIPLIER);
		}
	}

	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Adds force from the engine, according to player input.
	/// the cases are:
	/// - if the throttle is pressed while on the ground, apply ENGINE_THROTTLE_FORCE_GROUNDED
	/// - if the throttle is pressed while on the air, and the speed doesn't exceed max limit, apply ENGINE_THROTTLE_FORCE
	/// - if the brake is pressed while on the air, and the speed isn't lower than the minimum on the air, apply ENGINE_STOP_FORCE
	/// - if the plane is on the air and neither the throttle nor the brakes are pressed, apply ENGINE_NORMAL_FORCE.
	/// </summary>
	void AddEngineForceFromInput(){
		if (throttlePressed){
			if (!grounded && rigidbody.velocity.magnitude < MAX_VELOCITY) {
				rigidbody.AddForce (transform.up * ENGINE_THROTTLE_FORCE * -1); 
			}
			else if (grounded){
				rigidbody.AddForce (transform.up * ENGINE_THROTTLE_FORCE_GROUNDED * -1); 
			}
		} 
		else if (brakePressed && rigidbody.velocity.y > MINIMUM_ROTATION_SPEED) {
			rigidbody.AddForce (transform.up * ENGINE_STOP_FORCE * -1); 
		} 
		else if (!grounded){
			rigidbody.AddForce (transform.up * ENGINE_NORMAL_FORCE * -1); 
		}
	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Update the airplane
	/// </summary>
	void FixedUpdate()
	{
		if (currentRaceTrack.isStarted ()) {
			GetAllInput ();
		}
		RotatePlaneFromInput ();
		AddEngineForceFromInput ();
		UpdatePropeller ();
		Turbo ();
	}

	void Turbo(){
		//change camera view and add more force to the rigidbody
		if (turboPressed) {
			if (Camera.main.fieldOfView <120 && rigidbody.velocity.magnitude < MAX_VELOCITY * 2) {
				rigidbody.AddForce (transform.up * ENGINE_THROTTLE_FORCE * -1); 
				Camera.main.fieldOfView ++;
			}else{
				Camera.main.fieldOfView = 120;
			}
		} else if (Camera.main.fieldOfView >51) {
			Camera.main.fieldOfView --;
			//rigidbody.AddForce (transform.up * ENGINE_STOP_FORCE * -1); 
		}else{
			Camera.main.fieldOfView = 51;
		}
	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Handle airplane collisions
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.name == "Terrain")
		{
			HandleCollisionWithGround();
		}
	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Handle airplane collision with the ground.
	/// updates the boolean variable isGrounded on the animator, 
	/// and updates the local boolean variable grounded
	/// </summary>
	/// <param name="col">Col.</param>
	void HandleCollisionWithGround()
	{
		animator.SetBool("isGrounded", true);
		grounded = true;		
	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Handle the event when the airplane leaves the ground
	/// updates the boolean variable isGrounded on the animator, 
	/// and updates the local boolean variable grounded
	/// </summary>
	/// <param name="col">Col.</param>
	void HandleTakeoff()
	{
		animator.SetBool("isGrounded", false);
		grounded = false;		
	}


	/// ------------------------------------------------------------------------------------------------
	/// <summary>
	/// Handle airplane collision exit
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.name == "Terrain")
		{
			HandleTakeoff();
		}
	}
}
