using UnityEngine;
using System.Collections;

public class MenuLevels : MonoBehaviour {

	/// ------------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update() {

		bool isFinished = GameObject.Find ("RaceTrack").GetComponent<racetrack> ().isFinished() || Scene.GetLevel()==0;

		if (isFinished && Input.GetAxis ("Vertical") == 1) {
			GetComponent<TextMesh> ().text = "AirPort";
		} else if (isFinished && Input.GetAxis ("Vertical") == -1) {
			GetComponent<TextMesh> ().text = "Island";
		}

		if (isFinished && Input.GetButtonUp ("selectLevel")) {
			if (GetComponent<TextMesh>().text == "AirPort") {
				Scene.changeLevel(1);
				Application.LoadLevel(1);
			}	else if (GetComponent<TextMesh>().text == "Island") {
				Scene.changeLevel(2);
				Application.LoadLevel(2);
			}		
		}
	}
}
