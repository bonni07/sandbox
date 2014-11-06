using UnityEngine;
using System.Collections;

public class SimpleCameraFollow : MonoBehaviour {

    public static SimpleCameraFollow Instance;
	GameObject target;
	Transform targetPos;
	public Vector3 pos;

	//Camera follows player with an offset that can be set via Unity.

	void Start () {
        if (Instance == null)
        {
            Instance = this;
        }
		target = GameObject.FindGameObjectWithTag ("Player");
		targetPos = target.GetComponent<Transform> ();
	}

	void Update () {
		transform.position = targetPos.position + pos;
		transform.LookAt (targetPos);
	}

    public void ToggleMainCam()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}