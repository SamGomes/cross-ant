using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : MonoBehaviour {

    Animator animator;
	Animator queenAnimator;
	public float movementSpeed = 100;
	public Vector3 originalPosition;
	private float throwingStartTime = -1;

	private float lifetime = 10;
	// Use this for initialization
	void Start () {
      animator = this.gameObject.GetComponent<Animator>();
	  this.originalPosition = this.transform.position;
	  Destroy (gameObject, lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	  this.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
	  if(throwingStartTime < 0) {
	    return;
	  } else {
        float currenTime = Time.time;
        float difference = currenTime - throwingStartTime;
		if(difference > 4) {
		  this.animator.SetTrigger("walk");
		  if(queenAnimator != null) {
		    queenAnimator.SetTrigger("rest");
		  }
		  this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
	      movementSpeed = -5;
	      throwingStartTime = -1;
		}
	  }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
	  this.animator.SetTrigger("throw");
	  if(queenAnimator != null) {
	    queenAnimator.SetTrigger("beginEating");
	  }
	  movementSpeed = 0;
	  throwingStartTime = Time.time;
	}

	void walk() {
    
	}

	public void setQueenAnimator(Animator queen) {
        this.queenAnimator = queen;
	}
}
