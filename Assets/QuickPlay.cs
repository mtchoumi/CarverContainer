using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickPlay : MonoBehaviour
{
    public static float nextScenein = 10f;
    public static int lastSceneint = 0;
    public static int nextSceneint = 0;
    public static Animator anim;
    public const float TIMETOSWITCHSCENES = 60f;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nextScenein -= Time.deltaTime;
        //print(nextScenein);
        if (Input.anyKey)
        {
            nextScenein = TIMETOSWITCHSCENES;
        }
        if ((Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "CarverCenter_Start") || (nextScenein <= 0 && !SceneManager.GetActiveScene().name.Contains("CarverCenter")))
        {
            nextScene();
        }
        // if (Input.GetKey(KeyCode.Escape))
        // {
        //     SceneManager.LoadScene("CarverCenter_Main");
        // }
    }

    public static void nextScene()
    {
        // anim.SetBool("newScene", true);
        // anim.SetBool("newScene", false);
        while (lastSceneint == nextSceneint)
        {
            nextSceneint = Mathf.RoundToInt(Random.Range(0,File_Search.SceneNames.Count));
        }
        lastSceneint = nextSceneint;
        SceneManager.LoadScene(File_Search.SceneNames[nextSceneint]);
        nextScenein = TIMETOSWITCHSCENES;
    }


}
