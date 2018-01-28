using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartQuitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("v")){
			Application.Quit();
		}
		else if(Input.GetKey("z")){
			SceneManager.LoadScene("crossAnt");
		}
	}
}
