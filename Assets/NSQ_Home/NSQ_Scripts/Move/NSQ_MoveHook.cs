using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NSQ_MoveHook : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(Camera.main.orthographicSize*Camera.main.aspect);
        if(transform.position.x < Camera.main.orthographicSize*Camera.main.aspect && 
           transform.position.x > -Camera.main.orthographicSize*Camera.main.aspect && 
           transform.position.y < Camera.main.orthographicSize && 
           transform.position.y > -Camera.main.orthographicSize)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Time.deltaTime * speed;
        } else
        {
            Destroy(gameObject);
            SceneManager.LoadScene("NSQ_GameOver");
            
            NSQ_Score.score=0;
            NSQ_ScoreLvL2.score2=0;
            NSQ_ScoreLvL3.score3=0;
            NSQ_ScoreLvL4.score4=0;
        }
    }
}
