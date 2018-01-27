using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBehaviour : MonoBehaviour
{

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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
