using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject resultPanel;
    public GameObject hpPanel;
    public GameObject displayPanel;
    public GameObject scorePanel;
    public GameObject timePanel;
    public GameObject reqPanel;

    public GameObject Spawner;

    public string currWord;
    public string currTargetWord;

    public float timeLeft = 30.0f;


    private int lives;
    private int score;
    private string[] targetWords = { "CAKE", "PIE", "APPLE" , "PIZZA" , "CROISSANT" , "BANANA" , "DONUT", "CHERRY", "XMASCOOKIES" , "KIWI", "QUICHE", "MANGO", "FISH", "VANILLA", "JELLY" };

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("decrementTimeLeft", 0.0f, 1.0f);
        Application.targetFrameRate = 60;
        //timeLeft = 30.0f;
        lives = 3;

        DisplayPanel display = displayPanel.GetComponent<DisplayPanel>();
        
        currTargetWord = targetWords[0];
        display.setCurrWord(currTargetWord);
        reqPanel.GetComponent<reqScript>().updateRequirement(currTargetWord);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        resultPanel.GetComponent<UnityEngine.UI.Text>().text = "Word: "+ currWord;
        hpPanel.GetComponent<UnityEngine.UI.Text>().text = "Lifes: "+ lives;
        scorePanel.GetComponent<UnityEngine.UI.Text>().text = "Score: "+ score;
        timePanel.GetComponent<UnityEngine.UI.Text>().text = "Time: "+ timeLeft;

        currWord = currWord.ToUpper();

        if(timeLeft <= 0.0f || lives < 1)
        {
            SceneManager.LoadScene("gameover");
        }

        string cutTargetWord = currTargetWord.Substring(0, currWord.Length);

        if(currWord == ""){ return; }
        if (!cutTargetWord.Contains(currWord))
        {
            hurt();
        }
        else
        {
            if (currWord.CompareTo(currTargetWord) == 0)
            {
                score += currTargetWord.Length;
                timeLeft += currTargetWord.Length*2;
                antSpawner spawner = Spawner.GetComponent<antSpawner>();
                spawner.spawnAnt(currTargetWord);
                changeTargetWord();

            }
        }
    }

    void decrementTimeLeft()
    {
        timeLeft--;
    }

    void changeTargetWord()
    {
        int random = Random.Range(0, targetWords.Length);
        InvokeRepeating("spawnLetter", random, random);
        currTargetWord = targetWords[random];
        displayPanel.GetComponent<DisplayPanel>().setCurrWord(currTargetWord);
        reqPanel.GetComponent<reqScript>().updateRequirement(currTargetWord);
    }

    void hurt()
    {
        lives--;
        currWord = "";
    }
}
