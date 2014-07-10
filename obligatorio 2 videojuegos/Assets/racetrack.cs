using UnityEngine;
using System.Collections;

public class racetrack : MonoBehaviour {

	public int totalGoals = 14;
	public int currentGoal = 0;
	float startTime;
	float finishTime;
	bool finished = false;
	bool started = false;
	float referenceTime;

	public bool isStarted()
	{
		return started;
	}

	public void StartRace()
	{
		started = true;
		StartTimer ();
		//ShowTrackCompleted();
	}

	public bool isFinished()
	{
		return finished;
	}

	public void AddTimePenalty(int timePenalty)
	{
		startTime -= timePenalty;
	}

	public Transform GetCurrentGoal()
	{
		return getGoal (currentGoal);
	}

	public float GetElapsedTimeFloat(){
		if (!isStarted()) 
		{
			referenceTime = startTime;
		}
		else if (!finished) {
			referenceTime = Time.time;
		}
		else {
			referenceTime = finishTime;
		}
		
		return (referenceTime - startTime);
	}

	public string GetElapsedTime ()
	{
		float elapsedTime = GetElapsedTimeFloat ();
		float minutes  = Mathf.Floor(elapsedTime / 60);
		float seconds  = Mathf.Floor(elapsedTime % 60);
		float fraction = Mathf.Floor(elapsedTime * 100) % 100;
		string elapsedTimeString = string.Format ("Time: {0:00}:{1:00}:{2:000}", minutes, seconds, fraction); 

		return elapsedTimeString;
	}

	// Use this for initialization
	void Start () {
		Transform currentGoalCube = getGoal (currentGoal);
		if (currentGoalCube != null) {
			Light cubeLight = currentGoalCube.GetChild(0).light;
			cubeLight.color = Color.green;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void CompleteGoal(int goalNumber)
	{
		if (goalNumber == currentGoal) {
			CompleteCurrentGoal ();
			ChangeNextGoalColor ();
			currentGoal += 1;
			if (currentGoal != totalGoals) {
				ShowTrackCompleted();
			} 
		}
	}

	void ShowTrackCompleted()
	{
		Scene.AddRecords (GetElapsedTimeFloat());
		finished = true;
		finishTime = Time.time;
		audio.Play ();

		GameObject.Find ("ChooseLevel").GetComponent<TextMesh> ().text = "Choose Level";

	}
	
	void CompleteCurrentGoal ()
	{
		Transform currentGoalCube = getGoal (currentGoal);
		if (currentGoalCube != null) {
			Light cubeLight = currentGoalCube.GetChild(0).light;
			cubeLight.color = Color.yellow;
		}
		currentGoalCube.audio.PlayOneShot (currentGoalCube.audio.clip);
	}
	void ChangeNextGoalColor ()
	{
		Transform currentGoalCube = getGoal (currentGoal + 1);
		if (currentGoalCube != null) {

			Light cubeLight = currentGoalCube.GetChild(0).light;
			if (currentGoal == totalGoals){
				cubeLight.color = Color.green;
			}
			else{
				cubeLight.color = Color.red;
			}
		}
	}

	Transform getGoal(int number)
	{
		foreach (Transform goal in transform) {
			Transform goalTransform = goal.FindChild("Cube");
			collisionConeArea colliderArea = goalTransform.GetComponent<collisionConeArea>();
			int colliderTransformNumber = colliderArea.goalNumber;
			if (colliderTransformNumber == number){

				return goalTransform;
			}
		}
		return null;
	}

	void StartTimer()
	{
		startTime = Time.time;
	}
}