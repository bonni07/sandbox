using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class QuestionTree : MonoBehaviour {

	public GameObject Reset;
	public GameObject Question;
	public GameObject Answer;
    
	public GameObject YNPanel;
	public GameObject PasswordPanel;
	public GameObject SuccessPanel;
	public GameObject FailPanel;
    
	public Camera Option;
	public Camera Field;
	public Camera mainCamera;

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
		Question = GameObject.Find ("QuestionPanels");
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


	}

	//Functions for each button

	public void Correct () {
		Question.SetActive (false);
		FailPanel.SetActive (false);
		SuccessPanel.SetActive (true);
	}

	public void Incorrect () {
		Question.SetActive (false);
		FailPanel.SetActive (true);
		SuccessPanel.SetActive (false);
	}

	public void Retry () {
		Answer.SetActive (false);
		Question.SetActive (true);
	}

	public void Quit () {
		mainCamera.enabled = true;
	}
}