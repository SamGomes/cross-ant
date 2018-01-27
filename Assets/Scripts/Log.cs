using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    public Button ButtonLeft, ButtonRight;
	public GameObject[] islands;
	private int currentIslandNumber = 0;

	private bool clickedLeft = false;
	private bool clickedRight = false;

    void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;
        Ant topAnt = otherObject.GetComponent<Ant>();
        if (topAnt == null) //object colliding is not an ant
        {
            return;
        }
        other.gameObject.transform.SetParent(gameObject.transform);

    }

    void OnTriggerExit(Collider other)
    {
        GameObject otherObject = other.gameObject;
        Ant topAnt = otherObject.GetComponent<Ant>();
        if (topAnt == null) //object colliding is not an ant
        {
            return;
        }
        other.gameObject.transform.SetParent(null);

    }

    // Use this for initialization
    void Start()
    {
        Button btnLeft = ButtonLeft.GetComponent<Button>();
		Button btnRight = ButtonRight.GetComponent<Button>();
        btnLeft.onClick.AddListener(TaskOnClickLeft);	
		btnRight.onClick.AddListener(TaskOnClickRight);		        

    }

    // Update is called once per frame
    void Update()
    {

    }

	void TaskOnClickLeft(){
		clickedLeft = true;
		GameObject currentIsland = islands[currentIslandNumber];
		GameObject targetIsland = islands[(currentIslandNumber + 1) % islands.Length ];
		Vector3 currentIslandVector = currentIsland.transform.Find("Shape").transform.position;
		Vector3 targetIslandVector =  targetIsland.transform.Find("Shape").transform.position;
		float angle = Vector3.Angle(currentIslandVector,targetIslandVector);
		Vector3 cross = Vector3.Cross(currentIslandVector, targetIslandVector);
 
		if (cross.z < 0)
			angle = 360 - angle;
		transform.Rotate(Vector3.up,angle);
		
		currentIslandNumber = (currentIslandNumber + 1 ) % islands.Length;

	}

	void TaskOnClickRight(){
		clickedRight = true;
		GameObject currentIsland = islands[currentIslandNumber];

		int previousIslandNumber = (currentIslandNumber - 1);
		previousIslandNumber = previousIslandNumber < 0 ? islands.Length - 1 : previousIslandNumber;

		GameObject targetIsland = islands[previousIslandNumber];
		Vector3 currentIslandVector = currentIsland.transform.Find("Shape").transform.position;
		Vector3 targetIslandVector =  targetIsland.transform.Find("Shape").transform.position;
		float angle = Vector3.Angle(currentIslandVector,targetIslandVector);
		Vector3 cross = Vector3.Cross(currentIslandVector, targetIslandVector);
 
		if (cross.z < 0)
			angle = 360 - angle;
		transform.Rotate(Vector3.up,angle);
		
		currentIslandNumber = previousIslandNumber;
	}

}
