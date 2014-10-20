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

		mainCamera = Camera.main;
		checkCamera = null;

		//Define other variables.
		checkButton = GameObject.Find ("CheckButton");
		checkMenu = GameObject.Find ("CheckMenu");
		character = GameObject.FindGameObjectWithTag ("Player");
		text = checkButton.GetComponentInChildren<Text>();
	
	}

	void Update () {

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
		if (checkCamera != null ){
			checkCamera.enabled = !checkCamera.enabled;
		}

	}
}