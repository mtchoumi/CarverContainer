using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class DAP_TitleScreen : MonoBehaviour
{
    [SerializeField] private Text Highscores;

    private List<int> num = new List<int>();

    private string ReadDataPath;
    // Start is called before the first frame update
    void Start()
    {
        ReadDataPath = Application.dataPath;
        ReadDataPath = ReadDataPath.Substring(0, ReadDataPath.LastIndexOf("/"));
        print(ReadDataPath);
        #if UNITY_EDITOR
            ReadDataPath += "/Assets";
        #endif
        StreamReader reader = new StreamReader(ReadDataPath + "/DAP_Titlescreen/DAP_ScoreDatabase.txt");
        while (reader.Peek() >= 0)
        {
            num.Add(Int32.Parse(reader.ReadLine()));
        }

        reader.Close();
        num.Sort();
        num.Reverse();
        print(num[0].ToString() + num[1].ToString() + num[2].ToString() + num[3].ToString() + num[4].ToString());
        Highscores.text = "1. " + num[0].ToString() + "\n" + "2. " + num[1].ToString() + "\n" + "3. " +  num[2].ToString() + "\n" + "4. " +  num[3].ToString() + "\n" + "5. " + 
                          num[4].ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
