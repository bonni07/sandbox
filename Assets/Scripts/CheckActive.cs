using UnityEngine;
using System.Collections;

public class CheckActive : MonoBehaviour {
	
	Camera checkCamera;
	GameObject checkButton;

	void Start () {

		//Camera varies based on which GameObject this script is applied to
		checkCamera = GetComponentInChildren<Camera> ();
		checkButton = GameObject.Find ("CheckButton");

	}

	// checkButton and checkCamera only becomes active when player enters trigger

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			checkButton.SetActive (true);
			checkCamera.enabled = true;
		}
	}
	
	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			checkButton.SetActive (false);
			checkCamera.enabled = false;
		}
	}
}