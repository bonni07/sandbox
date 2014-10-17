using UnityEngine;
using System.Collections;

public class CheckActive : MonoBehaviour {
	
	Camera checkCamera;
	GameObject checkButton;

	void Start () {

		//Define variables. Camera varies based on which GameObject this script is applied to.
		checkCamera = GetComponentInChildren<Camera> ();
		checkButton = GameObject.Find ("CheckButton");
	}

	// When player enters trigger, checkButton becomes active and the camera of the group becomes the checkCam, and vice versa.

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			checkButton.SetActive (true);
			checkCamera.tag = "CheckCam";
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			checkButton.SetActive (false);
			checkCamera.tag = "NoCheckCam";
		}
	}
}