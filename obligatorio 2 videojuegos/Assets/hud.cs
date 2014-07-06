using UnityEngine;
using System.Collections;

public class hud : MonoBehaviour {

	Transform airplane;
	racetrack currentRaceTrack;
	GUIStyle speedGuiStyle;
	GUIStyle altitudeGuiStyle;
	GUIStyle goalsGuiStyle;


	// Use this for initialization
	void Start () {
		airplane = GameObject.Find ("airplane").transform;
		
		currentRaceTrack = GameObject.Find ("RaceTrack").GetComponent<racetrack> ();
		speedGuiStyle = new GUIStyle();
		speedGuiStyle.fontSize = 36;
		altitudeGuiStyle = new GUIStyle ();
		altitudeGuiStyle.fontSize = 24;
		goalsGuiStyle = new GUIStyle ();
		goalsGuiStyle.fontSize = 24;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		DrawSpeed ();
		DrawAltitude ();
		DrawElapsedTime ();
		DrawCompletedGoals ();
	}

	void DrawElapsedTime()
	{

	}

	void DrawCompletedGoals()
	{
		int totalGoals = currentRaceTrack.totalGoals;
		int currentGoal = currentRaceTrack.currentGoal;
		string completedGoalsString = "Completed: " + currentGoal + "/" + totalGoals;
		GUI.Box (new Rect ((Screen.width / 2) - 75 , 50, 150, 70), completedGoalsString, goalsGuiStyle);
	}

	void DrawSpeed()
	{
		double speed = airplane.rigidbody.velocity.magnitude;
		string speedString = Mathf.Round ((float)speed).ToString();
		string fullSpeedString = speedString + " km/h";
		GUI.Label (new Rect (Screen.width - 185, Screen.height - 50, 150, 30), fullSpeedString, speedGuiStyle);
	}

	void DrawAltitude()
	{
		float altitude = airplane.transform.position.y;
		string altitudeString = Mathf.Round (altitude).ToString();
		string fullAltitudeString = "Altitud: " + altitudeString + " m";
		GUI.Box (new Rect (Screen.width - 185, Screen.height - 270, 150, 70), fullAltitudeString, altitudeGuiStyle);
	}
}
