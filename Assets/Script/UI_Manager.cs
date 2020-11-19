﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public Text Score_;
    public Text Time_;
    public Text Remain_;

    private PlayerManager Playerm;

    int time = 0;
    long score = 0;
    // Use this for initialization
    void Awake() {
        Playerm = GameObject.Find("HitBox").GetComponent<PlayerManager>();
        Remain_.text = Playerm.Remain.ToString();
        
        StartCoroutine(TimeCoroutine());
        StartCoroutine(ScoreCoroutine());
    }
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate(){

    }

    IEnumerator TimeCoroutine()
    {
        while (true)
        {
            time++;
            Time_.text = time.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator ScoreCoroutine()
    {
        while (true)
        {
            score++;
            score += time;
            Score_.text = score.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
