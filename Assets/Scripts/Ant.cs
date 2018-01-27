using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{

    public GameObject foodObject;
    public GameObject moundDoor;
    public float speed;

    protected int cargoCapacity;
    //private
    public bool isCharged;

    // private Vector3 logEntryPosition;
    private Vector3 myInitialPosition;

    private Vector3 moundDoorPosition;
    private Vector3 foodObjectPosition;
    private Vector3 myPosition;

    GameObject ant;

    // Use this for initialization
    void Start()
    {
        isCharged = false;
        ant = gameObject;
        myInitialPosition = gameObject.transform.position;
        moundDoorPosition = moundDoor.transform.position;
        foodObjectPosition = foodObject.transform.GetChild(0).position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myPosition = gameObject.transform.position;
        Vector3 targetPos = new Vector3(0, 0, 0);
        Vector3 myDirection = new Vector3(0, 0, 0);

        if (!isCharged)
        {
            myDirection = foodObjectPosition - myPosition;
            targetPos = foodObjectPosition;
        }
        else
        {
            myDirection = moundDoorPosition - myPosition;
            targetPos = moundDoorPosition;
        }

        //walk animation play
        Vector3 myVelocity = myDirection.normalized * speed;

        //rotate towards target
        transform.LookAt(targetPos);
        //update ant movement
        ant.transform.position += myVelocity;
    }


}
