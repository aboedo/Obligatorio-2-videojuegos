using UnityEngine;
using System.Collections;

public class engineSound : MonoBehaviour {
	
	public const float MAXIMUM_PITCH = 3f;
	public const float MINIMUM_PITCH = 1f;
	public const float IDLE_PITCH = 2f;

	airplane airplane;
	bool isAccelerating;
	bool isBraking;
	int timeToAccelerate = 5;

	void Start() {
		audio.pitch = MINIMUM_PITCH;
		airplane = GameObject.Find ("airplane").GetComponent<airplane>();
	}
	void Update() {

		isAccelerating = airplane.isAccelerating ();
		isBraking = airplane.isBraking ();

		if (isAccelerating && audio.pitch < MAXIMUM_PITCH) {
			audio.pitch += Time.deltaTime * IDLE_PITCH / timeToAccelerate;
		}
		else if (isBraking && audio.pitch > MINIMUM_PITCH) {
			audio.pitch -= Time.deltaTime * IDLE_PITCH / timeToAccelerate;
		}
		else if (!airplane.isGrounded()){
			if (audio.pitch < IDLE_PITCH)
			{
				audio.pitch += Time.deltaTime * IDLE_PITCH / timeToAccelerate;
			}
			else if (audio.pitch > IDLE_PITCH)
			{
				audio.pitch -= Time.deltaTime * IDLE_PITCH / timeToAccelerate;
			}
		}
		else if (audio.pitch > MINIMUM_PITCH){
			audio.pitch -= Time.deltaTime * IDLE_PITCH / timeToAccelerate;
		}
		audio.PlayOneShot (audio.clip);
		
	}


}
