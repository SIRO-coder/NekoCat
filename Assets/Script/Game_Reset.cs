using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Reset : MonoBehaviour {

	[SerializeField] 
	public GameObject text;

	public float blink_delay = 5;
	private bool isBlinked = false;

	// Use this for initialization
	void Start () {
		StartCoroutine(Blink());
	}
	
	// Update is called once per frame
	void Update () {
		Inputs();
	}

	void Inputs()
	{
		if(Input.GetKeyDown(KeyCode.Return))
		{
			StopCoroutine(Blink());
			SceneManager.LoadScene("Game_main");
		}
	}

	IEnumerator Blink()
	{
		while(true)
		{
			if(!isBlinked)
			{
				text.SetActive(false);
				yield return new WaitForSeconds(blink_delay);
				isBlinked = true;
			}
			else
			{
				text.SetActive(true);
				yield return new WaitForSeconds(blink_delay);
				isBlinked = false;
			}
		}
	}
}
