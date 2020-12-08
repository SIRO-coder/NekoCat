using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	[SerializeField]
	private GameObject pauseUI;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			pauseUI.SetActive (!pauseUI.activeSelf);
			if(pauseUI.activeSelf){
				Time.timeScale = 0f;
			}
			else {
				Time.timeScale = 1f;
			}
		}
	}
}
