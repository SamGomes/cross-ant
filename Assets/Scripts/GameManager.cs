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
    public GameObject[] LetterSpawners;


    public string currWord;
    public string currTargetWord;

    public float timeLeft = 30.0f;


    public int lives = 4;
    private int score;
    private string[] targetWords = { "CAKE", "PIE", "APPLE" , "PIZZA" , "CROISSANT" , "BANANA" , "DONUT", "CHERRY", "XMASCOOKIES" , "KIWI", "QUICHE", "MANGO", "FISH", "VANILLA", "JELLY" };

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("decrementTimeLeft", 0.0f, 1.0f);
        Application.targetFrameRate = 60;
        //timeLeft = 30.0f;

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

        string cutTargetWord = currTargetWord;
        if(cutTargetWord.Length > currWord.Length)
        {
            cutTargetWord = currTargetWord.Substring(0, currWord.Length);
        }

        if (currWord == ""){ return; }
        if (!cutTargetWord.Contains(currWord))
        {
            hurt();
        }
        else
        {
            if (currWord.CompareTo(currTargetWord) == 0)
            {
                score += currTargetWord.Length;
                timeLeft += currTargetWord.Length*4;
                GameObject[] letters = GameObject.FindGameObjectsWithTag("letter");
                foreach (GameObject letter in letters)
                {
                    Destroy(letter);
                }
                foreach (GameObject LetterSpawner in LetterSpawners)
                {
                  LetterSpawner.GetComponent<LetterSpawner>().setScore(score);   
                }
                AntSpawner spawner = Spawner.GetComponent<AntSpawner>();
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
        currWord = "";
        displayPanel.GetComponent<DisplayPanel>().setCurrWord(currTargetWord);
        reqPanel.GetComponent<reqScript>().updateRequirement(currTargetWord);
    }

    void hurt()
    {
        lives--;
        currWord = "";
    }
}
