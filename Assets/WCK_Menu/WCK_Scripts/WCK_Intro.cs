using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WCK_Intro : MonoBehaviour
{
    GameObject cam;
    Camera camer;
    Animator anim;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        anim = GetComponent<Animator>();
        anim.Play("hole");
        cam = GameObject.Find("Main Camera");
        camer = cam.GetComponent<Camera>();
        camer.orthographicSize = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer != 0.0f) {
            timer += Time.deltaTime * 1.5f;
            camer.orthographicSize = timer;
        }
        if(timer > 5.0f) {
            timer = 0.0f;
            camer.orthographicSize = 5.0f;
            SceneManager.LoadScene("WCK_Main");
        }
    }

    public void Quit()
    {
        //Application.Quit();
        QuickPlay.nextScene();
    }

    public void Intro()
    {
        GameObject.Find("Canvas2").SetActive(false);
        anim.Play("intro");
        timer = 1.0f;
    }
}
