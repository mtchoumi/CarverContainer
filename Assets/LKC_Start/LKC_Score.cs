using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LKC_Score : MonoBehaviour
{
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.name.Contains("plate")){
            score = score + 1; 
            Destroy(gameObject);
            print(score); 
        }
        if(col.gameObject.name.Contains("bottomWall")){
            score= score - 1;
            Destroy(gameObject);
            print(score);
        }
        //if(score == 1){
                //SceneManager.LoadScene("LKC_Cup2");
            //}
        if(score == 5){
                SceneManager.LoadScene("LKC_Win");
                score = 0;
            } 
        if(score == -1){
            SceneManager.LoadScene("LKC_Lose");
            score = 0;
        }
    }
}
