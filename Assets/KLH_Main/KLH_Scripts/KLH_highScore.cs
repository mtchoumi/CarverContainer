using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KLH_highScore : MonoBehaviour
{

    GameObject highScore;
    GameObject enterScore;
    GameObject btnScore;
    GameObject scoreTxt;
    GameObject btnPlay;
    GameObject btnTxt;
    GameObject initialsTxt;
    GameObject dLight;
    GameObject camera;
    List<string> scores;
    string[] scoresArray;

    // Start is called before the first frame update
    void Start()
    {
        highScore = GameObject.Find("HighScores");
        enterScore = GameObject.Find("Initials");
        btnScore = GameObject.Find("Button");
        scoreTxt = GameObject.Find("Txt");
        initialsTxt = GameObject.Find("InitialsTxt");
        btnPlay = GameObject.Find("btnPlay");
        btnTxt = GameObject.Find("PlayTxt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScores(){
        //UI update
        string initials = initialsTxt.GetComponent<Text>().text;
        btnScore.active = false;
        scoreTxt.GetComponent<Text>().enabled = false;
        enterScore.active = false;
        highScore.GetComponent<Text>().enabled = true;
        btnPlay.GetComponent<Image>().enabled = true;
        btnTxt.GetComponent<Text>().enabled = true;
        GameObject.Find("btnQuit").GetComponent<Image>().enabled = true;
        GameObject.Find("quitTxt").GetComponent<Text>().enabled = true;
        GameObject.Find("credits").GetComponent<Text>().enabled = true;
        
        //sorts scores
        //Dictionary<int, int> integerScores = new Dictionary<int, int>();
        //Dictionary<int, string> allInitials = new Dictionary<int, string>();
        scores = File.ReadAllLines("./Assets/KLH_playerScores.txt").ToList();
        scores.Add(KLH_tramp.score+" "+initials);
        scoresArray = scores.ToArray();


        string[] x = scoresArray[scoresArray.Length-1].Split(' ');
        //Debug.Log("before: " + x[0]);
        for(var i = 0; i < 6-x[0].Length; i++){
            x[0] = "0" + x[0];
        }
        scoresArray[scoresArray.Length-1] = x[0] + " " + x[1];


        scores = scoresArray.ToList();
        foreach(string s in scores){
            Debug.Log(s);
        }
        //Debug.Break();

        int max = 0;
        int index = 0;
        List<string> sortedScores = new List<string>();
        int count = scores.Count;
        Debug.Log("count " + count);
        for(var k = 0; k < count; k++){
            for(var i = 0; i < scores.Count; i++){
                string temp = scores[i].Substring(0, 5);
                int indScore = int.Parse(temp);
                Debug.Log("Parsed: "+indScore);
                if(indScore>=max){
                    Debug.Log("replaced max " + max);
                    max = indScore;
                    index = i;
                    Debug.Log(index);
                }
            }
            string newTopScore = scores[index];
            sortedScores.Add(newTopScore);
            Debug.Log(newTopScore);
            scores.RemoveAt(index);
            index = 0;
            max = 0;
            //Debug.Break();
        }

        string scoresTxt = "";
        for(var i = 0; i < sortedScores.Count; i++){
            scoresTxt += (i+1) + ". " + sortedScores[i] + "\n";
        }
        highScore.GetComponent<Text>().text = scoresTxt;
        
        //writes new scores into file
        FileStream fs = new FileStream("./Assets/KLH_playerScores.txt", FileMode.Create, FileAccess.Write);  
        StreamWriter sw = new StreamWriter(fs);  
        sw.BaseStream.Seek(0, SeekOrigin.End);  
        scoresTxt = "";
        for(var i = 0; i < sortedScores.Count; i++){
            scoresTxt += sortedScores[i] + "\n";
        }
        sw.Write(scoresTxt);
        sw.Flush();
        sw.Close();
        fs.Close();        
    }

    public void PlayAgain(){
        SceneManager.LoadScene("KLH_Main");
        /*dLight = GameObject.Find("Directional Light");
        camera = GameObject.Find("Main Camera");
        camera.transform.rotation = Quaternion.Euler()*/
        KLH_tramp.score = 0;
        KLH_tramp.gameEnd = false;
    }

    public void Quit(){
        //Application.Quit();
        KLH_cam.started = false;
        KLH_cam.playReady = false;
        KLH_playerMove.sideFlips = 0;
        KLH_playerMove.flips = 0;
        KLH_playerMove.roundWorlds = 0;
        KLH_playerMove.flipping = false;
        KLH_playerMove.sideFlipping = false;
        KLH_playerMove.flipped = false;
        KLH_playerMove.sideFlipped = false;
        KLH_playerMove.flippingForward = false;
        KLH_playerMove.flippingBackward = false;
        KLH_playerMove.flipForwardReady = false;
        KLH_playerMove.flipBackwardReady = false;
        KLH_playerMove.sideFlippingLeft = false;
        KLH_playerMove.sideFlippingRight = false;
        KLH_playerMove.sideFlipRightReady = false;
        KLH_playerMove.sideFlipLeftReady = false;
        KLH_playerMove.roundWorldReady = false;
        KLH_playerMove.flipCombo = false;
        KLH_playerMove.flipIn = false;
        KLH_playerMove.flipComboIn = false;    
        KLH_playerMove.sideFlipIn = false;
        KLH_playerMove.trickCombo = 0;
        KLH_playerMove.sideFlipPos = 0;
        KLH_playerMove.flipPos = 0;
        KLH_tramp.play = false;
        KLH_tramp.gameEnd = false;
        KLH_tramp.score = 0;
        QuickPlay.nextScene();
    }
}
