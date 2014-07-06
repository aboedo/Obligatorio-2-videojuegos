using UnityEngine;
using System.Collections;

public class racetrack : MonoBehaviour {
	
	public int totalGoals = 10;
	public int currentGoal = 0;
	public Time elapsedTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void CompleteGoal(int goalNumber)
	{
		if (goalNumber == currentGoal) {
			currentGoal += 1;
			if (currentGoal == totalGoals) {
					Debug.Log ("You won!");
			} else {
					ChangeCurrentGoalColor ();
					ChangeNextGoalColor ();
			}
		}
	}
	
	void ChangeCurrentGoalColor ()
	{
		
	}
	void ChangeNextGoalColor ()
	{
		
	}
}