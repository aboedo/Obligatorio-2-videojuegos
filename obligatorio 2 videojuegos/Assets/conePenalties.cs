using UnityEngine;
using System.Collections;

public class conePenalties : MonoBehaviour {

	public int timePenaltyInSeconds = 2;

	racetrack racetrack;

	// Use this for initialization
	void Start () {
		racetrack = GameObject.Find ("RaceTrack").GetComponent<racetrack> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "airplane") 
		{
			audio.PlayOneShot(audio.clip);
			racetrack.AddTimePenalty(timePenaltyInSeconds);
		}
	}
}
