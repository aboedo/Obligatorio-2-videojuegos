using UnityEngine;
using System.Collections;

public class MenuLevels : MonoBehaviour {

	/// ------------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update() {

		bool isFinished = GameObject.Find ("RaceTrack").GetComponent<racetrack> ().isFinished() || Scene.GetLevel()==0;

		if (isFinished && Input.GetButtonUp ("changeLevel")) {
			if (GetComponent<TextMesh> ().text == "AirPort") {
				GetComponent<TextMesh> ().text = "Island";
			}else if (GetComponent<TextMesh> ().text == "Island") {
				GetComponent<TextMesh> ().text = "AirPort";
			}
		}



		if (isFinished && Input.GetButtonUp ("selectLevel")) {
			if (GetComponent<TextMesh>().text == "AirPort") {
				Scene.ChangeLevel(1);
			}	else if (GetComponent<TextMesh>().text == "Island") {
				Scene.ChangeLevel(2);
			}		
		}
	}
}
