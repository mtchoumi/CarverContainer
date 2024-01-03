using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Obj;
    public static float loadtime = 0f;
    //[SerializeField] private GameObject[] Info;
    // Start is called before the first frame update
    void Start()
    {
        if (Brain.isPlay) // if they pick a random games
        {
            loadtime = 2.5f;
            Brain.pickRan(); //Pick the next Game(Scene)
            Obj[0].gameObject.GetComponent<Text>().text = "Next Game: " + Brain.nextScene();
        }
        else
        {
            Obj[0].gameObject.GetComponent<Text>().text = "Next Game: Main";
        }
        try
        {
            string path = SceneUtility.GetScenePathByBuildIndex(Brain.random);
            path = path.Replace(".unity", ".txt");
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Obj[1].gameObject.GetComponent<Text>().text += line + "\n";
                }
            }
        }
        catch
        {
           Obj[1].gameObject.GetComponent<Text>().text = "No Info";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backMain()
    {
        SceneManager.LoadScene("CC_Main");
    }
}
