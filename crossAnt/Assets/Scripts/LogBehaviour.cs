using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : MonoBehaviour {
    private bool isHeld = false;
    public Camera camera;

	// Use this for initialization
	void Start () {
		//InvokeRepeating()
	}
	
	// Update is called once per frame
	void Update () {
        CheckMoving();
        MovePiece();
	}

    void MovePiece()
    {
        if(isHeld){

            Transform shape = transform.Find("Shape");
            //Vector3 logVector =  shape.position;
            // Vector3 mousePos = Input.mousePosition;
            // mousePos.y = Camera.main.pixelHeight - mousePos.y;
            
            // Vector3 mouseVector = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,Camera.main.nearClipPlane));

            Vector3 mouseVector = Input.mousePosition;
            Vector3 logVector = Camera.main.WorldToScreenPoint(shape.position);

            //Debug.Log("logVector = " + logVector);
            //Debug.Log("mouseVector = " + mouseVector);
            float angle = Vector3.Angle(logVector, mouseVector);
            if(angle > 3) angle = 3;

            var cross = Vector3.Cross(logVector, mouseVector);
            if (cross.z > 0) angle = -angle;       

            Debug.Log(angle);
            transform.Rotate(Vector3.up, angle);
        }
        
    }

    void CheckMoving()
    {
        if (Input.GetMouseButton(0))
        {
            Transform shape = transform.Find("Shape");
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if( hit.collider.gameObject == shape.gameObject ){
                    isHeld = true;
                }
            }
        }
        else {
            isHeld = false;
        }
    }

}
