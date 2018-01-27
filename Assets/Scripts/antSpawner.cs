using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antSpawner : MonoBehaviour {

	public GameObject antPrefab;
	public GameObject QueenAnt;

	// Use this for initialization
	void Start () {
	 /// spawnAnt();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawnAnt(){
     GameObject ant = Instantiate(antPrefab, this.transform.position, Quaternion.identity);
	 ant antScript = ant.GetComponent<ant>();
	 Animator queenAnimator  = QueenAnt.GetComponent<Animator>();
	 antScript.setQueenAnimator(queenAnimator);
	}
}
