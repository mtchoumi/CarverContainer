using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SEC_GameOverInputs : MonoBehaviour
{
    GameObject gameOver;
    GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GameObject.Find("GameOver");
        scoreText = GameObject.Find("ScoreText");
        if (SEC_Reticle.time > 0)
        {
            gameOver.GetComponent<Text>().color = Color.red;
            gameOver.GetComponent<Text>().text = "Game Over";
        }else
        {
            gameOver.GetComponent<Text>().color = Color.green;
            gameOver.GetComponent<Text>().text = "You Survived";
        }

        scoreText.GetComponent<Text>().text = "You got " + SEC_Reticle.score + " points!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPressPlayAgain()
    {
        SceneManager.LoadScene("SEC_Instructions");
    }

    public void OnPressExit()
    {
        SceneManager.LoadScene("Loading");
    }
}
