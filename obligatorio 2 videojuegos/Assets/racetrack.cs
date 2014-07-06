using UnityEngine;
using System.Collections;

public class racetrack : MonoBehaviour {
	
	public int totalGoals = 13;
	public int currentGoal = 0;
	public Time elapsedTime;

	public Transform GetCurrentGoal()
	{
		return getGoal (currentGoal);
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
			ChangeCurrentGoalColor ();
			ChangeNextGoalColor ();
			currentGoal += 1;
			if (currentGoal == totalGoals) {
					Debug.Log ("You won!");
			} else {
					
			}
		}
	}

	void ChangeCurrentGoalColor ()
	{
		Transform currentGoalCube = getGoal (currentGoal);
		if (currentGoalCube != null) {
			Light cubeLight = currentGoalCube.GetChild(0).light;
			cubeLight.color = Color.yellow;
		}
	}
	void ChangeNextGoalColor ()
	{
		Transform currentGoalCube = getGoal (currentGoal + 1);
		if (currentGoalCube != null) {

			Light cubeLight = currentGoalCube.GetChild(0).light;
			if (currentGoal + 1 == totalGoals){
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
}