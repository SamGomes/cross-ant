using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject resultPanel;
    public GameObject hpPanel;
    public GameObject displayPanel;
    public GameObject scorePanel;

    public GameObject Spawner;

    public string currWord;
    public string currTargetWord;


    private int lifes;
    private int score;
    private string[] targetWords = { "CAKE", "PIE", "APPLE" , "PIZZA" , "CROISSANT" , "BANANA" , "DONUT", "CHERRY", "XMASCOOKIES" , "KIWI", "QUICHE", "MANGO", "FISH", "VANILLA", "JELLY" };

    // Use this for initialization
    void Start()
    {
        lifes = 3;

        DisplayPanel display = displayPanel.GetComponent<DisplayPanel>();
        
        currTargetWord = targetWords[0];
        display.setCurrWord(currTargetWord);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        resultPanel.GetComponent<UnityEngine.UI.Text>().text = "Word: "+ currWord;
        hpPanel.GetComponent<UnityEngine.UI.Text>().text = "Lifes: "+ lifes;
        scorePanel.GetComponent<UnityEngine.UI.Text>().text = "Score: "+ score;

        currWord = currWord.ToUpper();

        if (!currTargetWord.Contains(currWord))
        {
            die();
        }
        else
        {
            if (currWord.CompareTo(currTargetWord) == 0)
            {
                score += currTargetWord.Length;
                antSpawner spawner = Spawner.GetComponent<antSpawner>();
                spawner.spawnAnt();
                changeTargetWord();

            }
        }
    }

    void changeTargetWord()
    {
        int random = Random.Range(0, targetWords.Length);
        InvokeRepeating("spawnLetter", random, random);
        currTargetWord = targetWords[random];
        displayPanel.GetComponent<DisplayPanel>().setCurrWord(currTargetWord);
    }

    void die()
    {
        if (lifes == 1)
        {
            //close game (switch scene to game over scene)
            Debug.Log("Game Over");
        }
        lifes--;
        currWord = "";
    }
}
