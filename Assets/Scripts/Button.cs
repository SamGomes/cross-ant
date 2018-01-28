using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public GameObject gameManager;
    public string buttonCode;
    public string xboxCode;

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
        if (this.clicked)
        {
            otherObject.gameObject.transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
            otherObject.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

            gameManager.GetComponent<GameManager>().currWord+=otherObject.gameObject.GetComponent<Letter>().letterText;
        }
    }
}
