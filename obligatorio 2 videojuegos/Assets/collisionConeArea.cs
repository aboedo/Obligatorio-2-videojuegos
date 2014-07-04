using UnityEngine;
using System.Collections;

public class collisionConeArea : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log("entra a la zona");
	}
	
	void OnTriggerStay(Collider other) {
		Debug.Log("esta a la zona");
		//other.rigidbody.transform.Rotate(Vector3.right * Time.deltaTime * hoverForce);
		//other.rigidbody.transform.Rotate(Vector3.forward * hoverForce, Space.World);
		//other.rigidbody.transform.Rotate(Vector3.up *hoverForce, Space.World);
	}
	
	void OnTriggerExit(Collider other) {
		Debug.Log("sale a la zona");
	}
}
