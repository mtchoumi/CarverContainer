using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NSQ_HatCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
            SceneManager.LoadScene("NSQ_GameOver");
            NSQ_Score.score = 0;
            NSQ_ScoreLvL2.score2 = 0;
            NSQ_ScoreLvL3.score3 = 0;
            NSQ_ScoreLvL4.score4 = 0;
        }
    }
}
