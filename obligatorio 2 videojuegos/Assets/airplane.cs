using UnityEngine;
using System.Collections;

public class airplane : MonoBehaviour {

	private float verticalAxis;
	private float horizontalAxis;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		rigidbody.AddForce (0, 0, 10);
		bool throttlePressed = Input.GetAxis("Throttle") == 1;
		bool brakePressed = Input.GetAxis("Brake") == 1;

		Debug.Log ("brake: " + brakePressed);
		Debug.Log ("throttle: " + throttlePressed);

		if (throttlePressed) {
			rigidbody.AddForce(transform.up * -30);
		}
		if (brakePressed) {
			rigidbody.AddForce(transform.up * 30);
		}

	}

	void FixedUpdate()
	{
		verticalAxis = Input.GetAxis ("Vertical");

		horizontalAxis = Input.GetAxis ("Horizontal");
		transform.Rotate (transform.forward * horizontalAxis);
		transform.Rotate(transform.right * verticalAxis);
		transform.FindChild("propeller").transform.Rotate (0, 10 * rigidbody.velocity.z, 0);




	}
}
