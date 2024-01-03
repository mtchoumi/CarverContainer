using System;
using UnityEngine;
using UnityEngine.UI;

public class DAP_ScoreMultiplier : MonoBehaviour
{
    [SerializeField] private GameObject EndPoint;

    private float Multiplier;

    public static bool StopScript = false;

    public static float score;
    
    [SerializeField] private Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        
        if (col.collider.CompareTag("Player"))
            {
                if (StopScript) return;
                Multiplier = Convert.ToSingle(Math.Pow(EndPoint.transform.position.x - transform.position.x, 2) +
                                              Math.Pow(EndPoint.transform.position.y - transform.position.y, 2));
                score += Multiplier / 10;
                ScoreText.text = "Score: " + Math.Floor(score);
            }
        
    }
}

