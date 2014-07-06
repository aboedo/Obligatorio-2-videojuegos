using UnityEngine;
using System.Collections;

public class backCamera : MonoBehaviour {
	private bool cameraShouldShow = false;
	// Use this for initialization
	void Start () {
		camera.enabled = cameraShouldShow;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("backCamera")) 
		{
			Debug.Log ("show cam");
			cameraShouldShow = !cameraShouldShow;
			camera.enabled = cameraShouldShow;
		}

	}
}
