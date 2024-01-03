using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SEP_MenuScript : MonoBehaviour
{
    public static int stageNum = 0;
    public static int starNum = 0;
    [SerializeField] private GameObject firstStar;
    [SerializeField] private GameObject secondStar;
    [SerializeField] private GameObject thirdStar;
    [SerializeField] private GameObject StartArrow;
    private float timer6 = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer6 += Time.deltaTime;
        if(stageNum == 0)
        {
            firstStar.SetActive(false);
            secondStar.SetActive(false);
            thirdStar.SetActive(false);
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("SEP_Stage1");
            }
        }
        if(stageNum == 1)
        {
            firstStar.SetActive(true);
                secondStar.SetActive(true);
                thirdStar.SetActive(true);
            StartArrow.SetActive(false);
            if(starNum == 0)
            {
                firstStar.SetActive(false);
                secondStar.SetActive(false);
                thirdStar.SetActive(false);
            }
            if(starNum == 1)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(false);
                thirdStar.SetActive(false);
            }
            if(starNum == 2)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(true);
                thirdStar.SetActive(false);
            }
            if(starNum == 3)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(true);
                thirdStar.SetActive(true);
            }
            if(timer6 > 2f)
            {
                StartArrow.SetActive(true);
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SceneManager.LoadScene("SEP_Stage2");
                }
            }
        }
            if(stageNum == 2 )
        {
            firstStar.SetActive(true);
            secondStar.SetActive(true);
            thirdStar.SetActive(true);
            StartArrow.SetActive(false);
            if(starNum == 0)
            {
                firstStar.SetActive(false);
                secondStar.SetActive(false);
                thirdStar.SetActive(false);
            }
            if(starNum == 1)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(false);
                thirdStar.SetActive(false);
            }
            if(starNum == 2)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(true);
                thirdStar.SetActive(false);
            }
            if(starNum == 3)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(true);
                thirdStar.SetActive(true);
            }
            if(timer6 > 2f)
            {
                StartArrow.SetActive(true);
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    SceneManager.LoadScene("SEP_Stage3");
                }
            }
        }
         if(stageNum == 3 )
        {
            firstStar.SetActive(true);
            secondStar.SetActive(true);
            thirdStar.SetActive(true);
            StartArrow.SetActive(false);
            if(starNum == 0)
            {
                firstStar.SetActive(false);
                secondStar.SetActive(false);
                thirdStar.SetActive(false);
            }
            if(starNum == 1)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(false);
                thirdStar.SetActive(false);
            }
            if(starNum == 2)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(true);
                thirdStar.SetActive(false);
            }
            if(starNum == 3)
            {
                firstStar.SetActive(true);
                secondStar.SetActive(true);
                thirdStar.SetActive(true);
            }
            if(timer6 > 2f)
            {
                SEP_MenuScript.stageNum = 0;
                starNum= 0;
                QuickPlay.nextScene(); 
                 
            }
        }
    }
}

