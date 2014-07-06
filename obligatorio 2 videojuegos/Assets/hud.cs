using UnityEngine;
using System.Collections;

public class hud : MonoBehaviour {

	Transform airplane;
	racetrack currentRaceTrack;
	GUIStyle speedGuiStyle;
	GUIStyle altitudeGuiStyle;
	GUIStyle goalsGuiStyle;
	GUIStyle elapsedTimeGuiStyle;


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
		elapsedTimeGuiStyle = new GUIStyle ();
		elapsedTimeGuiStyle.fontSize = 24;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		DrawSpeed ();
		DrawAltitude ();

		if (!currentRaceTrack.isFinished ()) {
			DrawTopCenterHudBox ();
			DrawElapsedTime ();
			DrawCompletedGoals ();
		}
		else 
		{
			DrawFinishedSign();
		}
	}

	void DrawFinishedSign()
	{
		int offsetX = 250;
		int offsetY = 125;
		GUIStyle finishedSignStyle = new GUIStyle();
		finishedSignStyle.fontSize = 36;
		GUIStyle detailsStyle = new GUIStyle ();
		detailsStyle.fontSize = 24;
		
		GUI.Box (new Rect (offsetX , offsetY, 
		                   (Screen.width) - (2 * offsetX), (Screen.height) - (offsetY * 2)), "");
		GUI.Label (new Rect ((Screen.width / 2) - 50, 135, 125, 70), "Finished", finishedSignStyle);
		string elapsedTimeString = currentRaceTrack.GetElapsedTime();
		GUI.Label (new Rect ((Screen.width / 2) - 75, 200, 125, 70), elapsedTimeString, detailsStyle);
		int totalGoals = currentRaceTrack.totalGoals;
		int currentGoal = currentRaceTrack.currentGoal;

		string completedGoalsString = "Completed Goals: " + currentGoal + "/" + totalGoals;
		GUI.Label (new Rect ((Screen.width / 2) - 100, 230, 125, 70), completedGoalsString, detailsStyle);
	}

	void DrawElapsedTime()
	{
		string elapsedTimeString = currentRaceTrack.GetElapsedTime();
		GUI.Box (new Rect ((Screen.width / 2) - 75 , 25, 125, 70), elapsedTimeString, goalsGuiStyle);
	}

	void DrawTopCenterHudBox ()
	{
		GUI.Box (new Rect ((Screen.width / 2) - 100 , 20, 225, 70), "");
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
