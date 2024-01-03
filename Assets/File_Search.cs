using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class File_Search : MonoBehaviour
{
    public bool rewriteFileInEditor;
    string SceneTextPath = "Scenes.txt";
    public static List<string> SceneNames = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_EDITOR
        if(rewriteFileInEditor)
        {
            string[] folders = AssetDatabase.GetSubFolders("Assets"); //Gets all the game Folders
            using (StreamWriter sw = new StreamWriter(SceneTextPath)) // get the Scenes.txt file
            {
                foreach(string folder in folders) // loops there all the game folders
                {
                    sw.WriteLine(folder.Replace("Assets/", "")); // Write the Scene Name into the Scenes.txt file
                }
            }
        }
        #endif
        using (StreamReader sr = new StreamReader(SceneTextPath))
        {
            while (sr.Peek() > -1)
            {
                string newGame = sr.ReadLine(); 
                if(newGame.Substring(0,2) != "**")
                {
                    SceneNames.Add(newGame);
                } 
                else
                {
                    print("fileRemoved");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
