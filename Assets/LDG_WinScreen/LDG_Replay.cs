using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LDG_Replay : MonoBehaviour
{
 void OnMouseDown()
    {
    SceneManager.LoadScene("LDG_Game"); 
    LDG_Display2.score = 3; 
    LDG_Display.score = 0;
    }
}
