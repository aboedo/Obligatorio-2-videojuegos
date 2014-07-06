using UnityEngine;
using System.Collections;

public class trail : MonoBehaviour {

	bool isGrounded = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = GameObject.Find ("airplane").GetComponent<airplane>().grounded;
		this.renderer.enabled = !isGrounded;
	}
}
