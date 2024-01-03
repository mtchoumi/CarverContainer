using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BCK_start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Own()
    {
        SceneManager.LoadScene("BCK_Play");
    }

    public void Nwo()
    {
        BCK_Display.score = 0f;
        BCK_Display.time2 = 31f;
        QuickPlay.nextScene();

    }
}
