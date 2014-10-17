using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CamSwitch : MonoBehaviour {

	Camera mainCamera;
	Camera checkCamera;

	GameObject checkButton;
	GameObject checkMenu;
	GameObject character;
	Text text;
	
	void Start () {

		//Find main camera and disable the rest, to be switched with SwitchCam function.
		//For some reason, this part seem to refuse to be overwritten with the function.
		foreach (Camera c in Camera.allCameras){
			if (c.gameObject.tag == "MainCamera") {
				mainCamera = c;
				mainCamera.enabled = true;
			} else {
				c.enabled = false;
			}
		}

		//Define other variables.
		checkButton = GameObject.Find ("CheckButton");
		checkMenu = GameObject.Find ("CheckMenu");
		character = GameObject.FindGameObjectWithTag ("Player");
		text = checkButton.GetComponentInChildren<Text>();
	
	}

	void Update () {

		//For each frame, check which camera now has the tag 'CheckCam' and define it as checkCamera.
		//For some reason, this part seem to not be checking every frame.
		foreach (Camera check in Camera.allCameras){
			if (check.gameObject.tag == "CheckCam") {
				checkCamera = check;
				Debug.ClearDeveloperConsole ();
			} else {
				checkCamera = null;
				Debug.Log ("NO CHECK CAMERA ASSIGNED");
			}
		}

		//Modify text in UI button according to which camera is in use.
		if (mainCamera.enabled == true){
			character.SetActive (true);
			checkMenu.SetActive (false);
			text.text = "CHECK";
		} else {
			character.SetActive (false);
			checkMenu.SetActive (true);
			text.text = "EXIT";
		}
	}

	public void SwitchCam (){

		//The button should switch between states.
		mainCamera.enabled = !mainCamera.enabled;
		checkCamera.enabled = !checkCamera.enabled;

	}
}