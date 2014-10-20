using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class QuestionTree : MonoBehaviour {

	GameObject YNPanel;
	GameObject PasswordPanel;
	GameObject SuccessPanel;
	GameObject FailPanel;

	Camera Option;
	Camera Field;
	Camera mainCamera;

	void Start () {

		mainCamera = Camera.main;

		//Find cameras.
		foreach (Camera q in Camera.allCameras) {
			if (q.gameObject.tag == "Question") {
				Option = q;
			} else if (q.gameObject.tag == "Password") {
				Field = q;
			} else {
				Option = null;
				Field = null;
			}
		}

		//Define variables.
		YNPanel = GameObject.Find ("YNPanel");
		PasswordPanel = GameObject.Find ("PasswordPanel");
		SuccessPanel = GameObject.Find ("SuccessPanel");
		FailPanel = GameObject.Find ("FailPanel");

	}

	void Update () {

		//Check state.
		if (YNPanel.activeSelf == true) {
			SuccessPanel.SetActive (false);
			FailPanel.SetActive (false);
		} else {
			SuccessPanel.SetActive (true);
			FailPanel.SetActive (true);
		}
		
		//Selecting which initial screen to show.
		if (Option != null) {
			if (Option.enabled == true) {
				YNPanel.SetActive (true);
			} else {
				YNPanel.SetActive (false);
			}
		}
		
		if (Field != null) {
			if (Field.enabled == true) {
				PasswordPanel.SetActive (true);
			} else {
				PasswordPanel.SetActive (false);
			}
		}
	}

	//Functions for each button.

	public void Correct () {
		YNPanel.SetActive (false);
		PasswordPanel.SetActive (false);
		SuccessPanel.SetActive (true);
		FailPanel.SetActive (false);
	}

	public void Incorrect () {
		YNPanel.SetActive (false);
		PasswordPanel.SetActive (false);
		SuccessPanel.SetActive (false);
		FailPanel.SetActive (true);
	}

	public void Retry () {
		SuccessPanel.SetActive (false);
		FailPanel.SetActive (false);
	}

	public void Quit () {
		Option.enabled = false;
		Field.enabled = false;
		mainCamera.enabled = true;
	}
}