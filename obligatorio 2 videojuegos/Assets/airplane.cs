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
		float fire1Pressed = Input.GetAxis("Fire1");


		Debug.Log(fire1Pressed + "");
		//		float fire2Pressed = Input.GetAxis ("Fire2");
		rigidbody.AddForce(transform.up * fire1Pressed * -30);
		//		rigidbody.AddForce(transform.up * fire2Pressed * 30);

	}

	void FixedUpdate()
	{
		verticalAxis = Input.GetAxis ("Vertical");

		horizontalAxis = Input.GetAxis ("Horizontal");
//		transform.Rotate (transform.forward * horizontalAxis);
//		transform.Rotate(transform.right * verticalAxis);




	}
}
