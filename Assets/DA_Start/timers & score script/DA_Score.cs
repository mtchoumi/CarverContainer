using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DA_Score : MonoBehaviour

{
     public static int score;
        public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "score: ";
    }

    // Update is called once per frame
    void Update()
    {
       ScoreText.text = "score: " + score; 
    }
}