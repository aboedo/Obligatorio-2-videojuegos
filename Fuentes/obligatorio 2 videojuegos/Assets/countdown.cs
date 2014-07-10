using UnityEngine;
using System.Collections;

public class countdown : MonoBehaviour {

	public Texture texture3;
	public Texture texture2;
	public Texture texture1;
	public Texture textureGo;

	racetrack currentRaceTrack;
	float startTime;
	float referenceTime;
	bool countDownStarted = false;
	bool countDownFinished = false;
	// Use this for initialization
	void Start () {
		currentRaceTrack = GameObject.Find ("RaceTrack").GetComponent<racetrack> ();
	}
	
	// Update is called once per frame
	void OnGUI () {
		if (!countDownFinished) {
			int offset = 300;

			if (!countDownStarted && !currentRaceTrack.isStarted ()) {
					startTime = Time.time;
					countDownStarted = true;
			}
			referenceTime = Time.time;
			if (referenceTime < startTime + 1) {

				GUI.DrawTexture(new Rect (offset , offset, 
				                          (Screen.width) - (2 * offset), (Screen.height) - (offset * 2)), texture3, ScaleMode.ScaleToFit, true, 0f);
			}

			else if (referenceTime < startTime + 2) {
				GUI.DrawTexture(new Rect (offset , offset, 
				                          (Screen.width) - (2 * offset), (Screen.height) - (offset * 2)), texture2, ScaleMode.ScaleToFit, true, 0f);
			}
			else if (referenceTime < startTime + 3) {
				GUI.DrawTexture(new Rect (offset , offset, 
				                          (Screen.width) - (2 * offset), (Screen.height) - (offset * 2)), texture1, ScaleMode.ScaleToFit, true, 0f);
			}
			else if (referenceTime < startTime + 4) {
				currentRaceTrack.StartRace();
				GUI.DrawTexture(new Rect (offset , offset, 
				                          (Screen.width) - (2 * offset), (Screen.height) - (offset * 2)), textureGo, ScaleMode.ScaleToFit, true, 0f);
			}


			else {
				countDownFinished = true;
			}
		}
	
	}
}
