using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GGV_SendBack : MonoBehaviour
{
    private float time7 = 0.0f;
    private float interval7 = 5f;
    // Start is called before the first frame update
    void Start()
    {
        time7 = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time7 += Time.deltaTime;
        if(time7 >= interval7)
        {
            SceneManager.LoadScene("GGV_MainMenu");
        }
    }
}
