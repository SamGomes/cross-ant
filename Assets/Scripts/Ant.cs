using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    public GameObject target;
    public float speed;

    protected int cargoCapacity;
    private bool isLoaded;

    // private Vector3 logEntryPosition;

    private Vector3 moundDoorPosition;
    private Vector3 foodObjectPosition;
    private Vector3 targetPosition;
    private Vector3 myPosition;

    private bool canMoove;

    // Use this for initialization
    void Start()
    {
        isLoaded = false;
        canMoove = false;
        myPosition = new Vector3(0, 0, 0);
        gameObject.transform.position = myPosition;
        targetPosition = target.transform.position;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canMoove)
        {
            return;
        }

        myPosition = gameObject.transform.position;
        Vector3 myDirection = new Vector3(0, 0, 0);

        myDirection = targetPosition - myPosition;

        //walk animation play
        Vector3 myVelocity = myDirection.normalized * speed;

        Debug.Log(myVelocity);
        //rotate towards target
        gameObject.transform.LookAt(targetPosition);
        //update ant movement
        gameObject.transform.position += myVelocity;
    }
    public bool checkIfLoaded()
    {
        return isLoaded;
    }
    public void moove()
    {
        this.canMoove = true;
    }
    public void stop()
    {
        this.canMoove = false;
    }

}
