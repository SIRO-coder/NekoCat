using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour {

    public float scrollSpeed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

    }
    void FixedUpdate()
    {
        transform.position -= new Vector3(Time.deltaTime * scrollSpeed, 0);
        if(transform.position.x <= -13.1f)
        {
            transform.position = new Vector2(-3f, 0);
        }
    }
}
