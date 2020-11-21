using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_selection : MonoBehaviour {

	public Text game_start; 
	public Text Select;

	private bool toggle = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		decision();
	}

	void decision()
	{
		if(Input.GetKey(KeyCode.Return) && !toggle)
		{
			toggle = true;
			SceneManager.LoadScene("Game_main");
		}
	}
}
