using UnityEngine;
using System.Collections;

public class MenuLevels : MonoBehaviour {

	/*public void OnMouseDown(){
		// if we clicked the play button
		if (this.name == "PlayAirPort")
		{
			// load the game
			Application.LoadLevel(1);
		}else if (this.name == "PlayIsland") {
			// load the game
			Application.LoadLevel(2);
		}
	}*/

	/// ------------------------------------------------------------------------------------------------
	// Update is called once per frame
	void Update() {
		if (Input.GetAxis ("Vertical") == 1) {
			GetComponent<TextMesh>().text = "AirPort";
			Debug.Log("up");
		} else if (Input.GetAxis ("Vertical") == -1) {
			GetComponent<TextMesh>().text = "Island";
			Debug.Log("down");
		}

		if (Input.GetButtonUp ("selectLevel")) {
			if (GetComponent<TextMesh>().text == "AirPort") {
				Application.LoadLevel(1);
			}	else if (GetComponent<TextMesh>().text == "Island") {
				Application.LoadLevel(2);
			}		
		}
	}
}
