using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class QuestionTree : MonoBehaviour {

	GameObject Reset;
	GameObject Answer;

	GameObject YNPanel;
	GameObject PasswordPanel;
	GameObject SuccessPanel;
	GameObject FailPanel;

	Camera Option;
	Camera Field;
	Camera mainCamera;

	void Start () {

		mainCamera = Camera.main;

		//Find cameras
		foreach (Camera q in Camera.allCameras) {
			if (q.gameObject.tag == "Question") {
				Option = q;
			} else if (q.gameObject.tag == "Password") {
				Field = q;
			}
		}

		//Define variables
		Reset = GameObject.Find ("_ResetHandler");
		Answer = GameObject.Find ("AnswerPanels");

		YNPanel = GameObject.Find ("YNPanel");
		PasswordPanel = GameObject.Find ("PasswordPanel");
		SuccessPanel = GameObject.Find ("SuccessPanel");
		FailPanel = GameObject.Find ("FailPanel");

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

	void Update () {

		//Initial Question state
		if (Reset.activeSelf == true) {
			if (YNPanel.activeSelf == true) {
				Answer.SetActive (false);
				Reset.SetActive (false);
			}
		}

		//Activate Answers
		if (YNPanel.activeSelf == false) {
			Answer.SetActive (true);
		}

		//Either/Or
		if (SuccessPanel.activeSelf == true) {
			FailPanel.SetActive (false);
		} else {
			FailPanel.SetActive (true);
		}
		if (FailPanel.activeSelf == true) {
			SuccessPanel.SetActive (false);
		} else {
			SuccessPanel.SetActive (true);
		}

		//Reactivate Reset
		if (mainCamera.enabled == true) {
			Reset.SetActive (true);
		}

		//Reset YNPanel's active state
		if (mainCamera.enabled == false) {
			if (Reset.activeSelf == true) {
				YNPanel.SetActive (true);
			}
		}
	}

	//Functions for each button

	public void Correct () {
		YNPanel.SetActive (false);
		FailPanel.SetActive (false);
		SuccessPanel.SetActive (true);
	}

	public void Incorrect () {
		YNPanel.SetActive (false);
		FailPanel.SetActive (true);
		SuccessPanel.SetActive (false);
	}

	public void Retry () {
		Answer.SetActive (false);
		YNPanel.SetActive (true);
	}

	public void Quit () {
		mainCamera.enabled = true;
	}
}