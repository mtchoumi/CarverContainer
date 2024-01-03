using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SEP_RenText : MonoBehaviour
{
    public Text menuText;
    // Start is called before the first frame update
    void Start()
    {
      menuText = GameObject.Find("Text").GetComponent<Text>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(SEP_MenuScript.stageNum == 0 )
        {
            menuText.text = "Mash the arrow keys displayed on screen. Press up to start!";
        }
        if(SEP_MenuScript.stageNum == 1)
        {
            menuText.text = "Hit the arrow key that shows up as many times as you can. Press up to start!";
        }
        if(SEP_MenuScript.stageNum == 2)
        {
            menuText.text = "Press up when the reticle is above the bottle. Press up to start!";
        }
        if(SEP_MenuScript.stageNum == 3)
        {
            menuText.text = "Congratulations! You finished making the potion!";
        }
    }
}
