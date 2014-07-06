using UnityEngine;
using System.Collections;

public class collisionConeArea : MonoBehaviour {

	public int goalNumber = 0;

	public racetrack circuit;

	void Start () {
		circuit = transform.parent.parent.GetComponent<racetrack> ();
		Debug.Log (circuit);
	}

	void OnTriggerEnter(Collider other) {
		CompleteGoal ();
	}
	
	void OnTriggerStay(Collider other) {
	}
	
	void OnTriggerExit(Collider other) {
	}

	void CompleteGoal(){
		circuit.CompleteGoal (goalNumber:goalNumber);
	}

}
