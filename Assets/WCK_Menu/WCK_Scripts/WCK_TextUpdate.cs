using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WCK_TextUpdate : MonoBehaviour
{
	Text txt, txt2;
	bool hidden;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        txt2 = GameObject.Find("Text2").GetComponent<Text>();
		hidden = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetScore(int score) {
		if(!hidden) {
			txt.text = "Hit Points: " + score;
		}
	}
	
	public void HideScore() {
		hidden = true;
		txt.text = "";
	}

    public void SetCenterText(string str) {
        txt2.text = str;
    }
}
