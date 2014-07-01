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
	}

	void FixedUpdate()
	{
		verticalAxis = Input.GetAxis ("Vertical");
		horizontalAxis = Input.GetAxis ("Horizontal");
		transform.Rotate (transform.forward * horizontalAxis);
		transform.Rotate(transform.right * verticalAxis);

		rigidbody.velocity =  transform.up * -10;

	}
}
