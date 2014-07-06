using UnityEngine;
using System.Collections;

public class collisionConeArea : MonoBehaviour {

	public int goalNumber = 0;

	public racetrack circuit;

	void Start () {
		circuit = transform.parent.parent.GetComponent<racetrack> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "airplane") {
			Debug.Log ("trigger enter");
			CompleteGoal ();
		}
	}
	
	void OnTriggerStay(Collider other) {
	}
	
	void OnTriggerExit(Collider other) {
	}

	void CompleteGoal(){
		circuit.CompleteGoal (goalNumber:goalNumber);
		audio.PlayOneShot (audio.clip);
	}

}
