using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MJB_TimeScore : MonoBehaviour
{
    float timer;
    GameObject txtScore;
    public static float score;
    public static float hits;

    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
        score = 0;
        timer = 0;
        txtScore = GameObject.Find("TimeScore");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        txtScore.GetComponent<Text>().text = "Timer: " + timer + "\n" + "Score: " + score + " Hits: " + hits;
    }
}