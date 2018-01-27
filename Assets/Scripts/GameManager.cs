using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public GameObject antPrefab;

    private List<GameObject> enabledIslands;
    private GameObject mound;
    private List<GameObject> ants;

    // Use this for initialization
    void Start () {
        ants = new List<GameObject>();
        enabledIslands = GameObject.FindGameObjectsWithTag("islandEnabled").ToList();
        int numIslands = enabledIslands.Count;

        Debug.Log(enabledIslands[0]);

        mound = GameObject.FindGameObjectsWithTag("mound")[0];

        Ant antPrefabScript = antPrefab.GetComponent<Ant>();
        int random = (int) Random.Range(0, numIslands-1);
        antPrefabScript.target = enabledIslands[0];
        antPrefabScript.speed = 0.5f;
        ants.Add(Instantiate(antPrefab));

        antPrefabScript = antPrefab.GetComponent<Ant>();
        random = (int)Random.Range(0, numIslands);
        antPrefabScript.target = enabledIslands[1];
        antPrefabScript.speed = 0.5f;
        ants.Add(Instantiate(antPrefab));

    }
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject ant in ants)
        {
            ant.GetComponent<Ant>().moove();
        }
	}
}
