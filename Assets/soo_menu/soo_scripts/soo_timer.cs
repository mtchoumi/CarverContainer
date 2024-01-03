using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class soo_timer : MonoBehaviour
{
    private float countdown;
    float sec;
    // Start is called before the first frame update
    void Start()
    {
        countdown = 30;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("countdown").GetComponent<Text>().text = "0"+countdown;
        countdown -= Time.deltaTime;
        if(countdown >= 3)
        {

        }
        if  (countdown <=0)
        {
            SceneManager.LoadScene("soo_gamewon");
        }
    }
}
