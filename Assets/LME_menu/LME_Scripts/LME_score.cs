using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LME_score : MonoBehaviour
{
    public static int score;
    public static int level = 1;
    void Update()
    {
        GameObject.Find("score").GetComponent<Text>().text="SCORE: "+Mathf.FloorToInt(score);
    }
}
