using UnityEngine;
using System.Collections;

public class hud : MonoBehaviour {

	Transform speedoMeter;
	Transform airplane;
	GUIStyle style;

	// Use this for initialization
	void Start () {
		airplane = GameObject.Find ("airplane").transform;
		style = new GUIStyle();
		style.fontSize = 36;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		double speed = airplane.rigidbody.velocity.magnitude;
		string speedString = Mathf.Round ((float)speed).ToString();
		string fullSpeedString = speedString + " km/h";

		GUI.Label (new Rect (Screen.width - 175, Screen.height - 50, 150, 30), fullSpeedString, style);
	}
}
