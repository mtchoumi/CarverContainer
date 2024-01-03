/*using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JEK_Achievements : MonoBehaviour
{
    //static FileStream achFile = new FileStream("/Users/jacksonkrausche/Downloads/Template/Assets/JEK_Game/JEK_Achievements.txt", FileMode.OpenOrCreate);
    //static FileStream highFile = new FileStream("Assets / JEK_Game / JEK_Highscores.txt", FileMode.OpenOrCreate);
    //StreamWriter writer = new StreamWriter(achFile);
    //StreamReader reader = new StreamReader(achFile);
    //StreamReader steve = new StreamReader("/Users/jacksonkrausche/Downloads/Template/Assets/JEK_Game/JEK_Achievements.txt");
    //List<StreamReader> iLoveStreamReaders = new List<StreamReader>();
    StreamReader jobs = new StreamReader("./Assets/JEK_Game/JEK_Highscores.txt");
    public GameObject claimer1, claimer2, claimer3, claimer4, claimer5, claimer6, claimer7;
    List<string> highscores = new List<string>();
    public static List<string> achievers = new List<string>() {"No one", "No one", "No one", "No one", "No one"};
    int highValIndex = 0;
    int lowScoreIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        while (jobs.Peek() >= 0)
        {
            highscores.Add(jobs.ReadLine());
        }
        /*
        jobs.Close();
        while (steve.Peek() >= 0)
        {
            achievers.Add(steve.ReadLine());
        }
        steve.Close();
        for (int i=0; i<achievers.Count; i++)
        {
            print(achievers[i]);
        }
        int highVal = 0;
        int bruh = highscores.Count;
        for (int i = 0; i < bruh; i++)
        {
            int theHighscoreThing;
            string tennis = highscores[i].Substring(0, 3);
            int.TryParse(tennis, out theHighscoreThing);
            if (theHighscoreThing > highVal)
            {
                highVal = theHighscoreThing;
                highValIndex = i;
            }
        }
        for (int i = 0; i < bruh; i++)
        {
            int theHighscoreThing;
            string tennis = highscores[i].Substring(0, 3);
            int.TryParse(tennis, out theHighscoreThing);
            if (theHighscoreThing < highVal)
            {
                highVal = theHighscoreThing;
                lowScoreIndex = i;
            }
        }
        //iLoveStreamReaders.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve1.txt"));
        //iLoveStreamReaders.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve2.txt"));
        //iLoveStreamReaders.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve3.txt"));
        //iLoveStreamReaders.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve4.txt"));
        //iLoveStreamReaders.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve5.txt"));
        claimer1.GetComponent<Text>().text = "Claimed by: " + achievers[0];
        claimer2.GetComponent<Text>().text = "Claimed by: " + achievers[1];
        claimer3.GetComponent<Text>().text = "Claimed by: " + achievers[2];
        claimer4.GetComponent<Text>().text = "Claimed by: " + achievers[3];
        claimer5.GetComponent<Text>().text = "Claimed by: " + achievers[4];
        claimer6.GetComponent<Text>().text = "Claimed by: " + highscores[highValIndex];
        claimer7.GetComponent<Text>().text = "Claimed by: " + highscores[lowScoreIndex];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void backToTheScreen()
    {
        SceneManager.LoadScene("JEK_Title");
    }
}
*/
