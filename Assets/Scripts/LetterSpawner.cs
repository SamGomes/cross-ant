using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public GameObject letterPrefab;
    public GameObject killTrigger;

    private string[] letters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "L", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

    // Use this for initialization
    void Start()
    {
        float random = Random.Range(0.5f, 2.5f);
        InvokeRepeating("spawnLetter", 0.0f, random);
    }

    void spawnLetter()
    {
        GameObject newLetter = Instantiate(letterPrefab);

        SpriteRenderer letterRenderer = newLetter.transform.GetComponent<SpriteRenderer>();

        int random = Random.Range(0, 25);
        string currLetter = letters[random];

        string path = "Textures/Alphabet/" + currLetter;

        letterRenderer.sprite = (Sprite) Resources.Load(path, typeof(Sprite));

        newLetter.transform.position = gameObject.transform.position;
        newLetter.transform.rotation = gameObject.transform.rotation;

    }


}
