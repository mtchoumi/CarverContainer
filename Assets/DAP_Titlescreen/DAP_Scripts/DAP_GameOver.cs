using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class DAP_GameOver : MonoBehaviour
{
    [SerializeField] private Text FinalScoreText;

    private string ReadText;

    private string DataPath;

    
    // Start is called before the first frame update
    void Start()
    {
        DataPath = Application.dataPath;
        DataPath = DataPath.Substring(0, DataPath.LastIndexOf("/"));
        FinalScoreText.text = "Final Score: " + Math.Floor(DAP_Trigger.FinalScore);
        #if UNITY_EDITOR
            DataPath += "/Assets";
        #endif
        StreamWriter writer = new StreamWriter(DataPath + "/DAP_Titlescreen/DAP_ScoreDatabase.txt", true);
        writer.WriteLine(Math.Floor(DAP_Trigger.FinalScore));
        writer.Close();

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
