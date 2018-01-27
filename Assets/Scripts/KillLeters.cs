using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillLeters : MonoBehaviour {

    void OnTriggerEnter(Collider otherObject)
    {
        Debug.Log("killLeters");
        Destroy(otherObject.GetComponent<SpriteRenderer>().gameObject);
        Destroy(otherObject.gameObject);
    }
}
