using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Brain : MonoBehaviour
{
    private Scene scene;
    public static string nextscenepath;
    public static int random = 0;
    public static int scenenum = 0;
    public static bool isPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadSceneAsync("Name", LoadSceneMode.Additive);
        //SceneManager.UnloadScene("Name");
    }

    void FixedUpdate()
    {
        if(scene.name == "Loading") // Do only if on Loading scene
        {
            LoadingUI.loadtime -= Time.deltaTime; //Create the timer
            for (int i = 8; i < 14; i++)
            {
                for (int j = i + 1; j < 14; j++)
                {
                    Physics2D.IgnoreLayerCollision(i,j,false); //loop through the layer and rest collision
                }
            }
            if (LoadingUI.loadtime <= 0) // if the timer hits zero
            {
                if (isPlay) // if they pick a random games
                {
                    SceneManager.LoadScene(random);//load the random scene
                    scenenum = random;
                }
                else if (!isPlay) // if they pick to play one game
                {
                    SceneManager.LoadScene("CC_Main"); //go back to main
                    scenenum = random;
                }
                LoadingUI.loadtime = 0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
    }

    public static void pickRan()
    {
        while (random == scenenum)
        {
            random = (int) (Random.Range(2,42)); //get a random number
        }
    }

    public void quickPlay()
    {
        SceneManager.LoadScene("Loading");
        isPlay = true;
    }

    public static string nextScene()
    {
        try
        {
            string path = SceneUtility.GetScenePathByBuildIndex(random);
            path = path.Replace(".unity", ".txt");
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadLine();
            }
        }
        catch
        {
            return "No File";
        }
    }
}
