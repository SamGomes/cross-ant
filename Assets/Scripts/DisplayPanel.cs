﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPanel : MonoBehaviour {

    private string currWord = "default";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void setCurrWord(string currWord)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = (Sprite) Resources.Load("Textures/FoodItems/" + currWord, typeof(Sprite));
        this.currWord = currWord;
    }
}
