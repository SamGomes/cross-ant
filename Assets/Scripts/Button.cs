﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject gameManager;
    public string buttonCode;

    private bool clicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(buttonCode))
        {
            this.gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            this.clicked = true;
        }else
        {
            this.clicked = false;
            this.gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

    }

    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.GetComponent<Letter>()== null){
            return;
        }
        Debug.Log(otherObject.GetComponent<Letter>());
        if (this.clicked)
        {
            gameManager.GetComponent<GameManager>().currWord+=otherObject.gameObject.GetComponent<Letter>().letterText;
        }
    }
}
