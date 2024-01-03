using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DA_window : MonoBehaviour
{
    public bool clean;
    float timer;
    Animator anim;
    public float targetTime;
    int numofclicks; 
    // Start is called before the first frame update
    void Start()
    {                
        numofclicks = 0;
        clean=true;
     timer = Random.Range(3f, 25f); 
     anim = GetComponent<Animator>();
     targetTime = 4.398f;   
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
     
        if(timer <=0f && clean == true)
        {
            anim.SetBool("red",false);
            anim.SetBool("winy",true);
            clean=false;
            timer = 0f;
              
        }
        if(clean==false)
        {
            targetTime -= Time.deltaTime;
        }
        // if (targetTime <= 0.0f && numofclicks>0)
        // {
        //     timerEnded();
        // } 
        if (transform.position.x <= 0.68)
        {
            
        } 
    }



    void timerEnded()    
    { 
        anim.SetBool("red",true);
        anim.SetBool("winy",false);
        // clean = true;
         numofclicks = 0;
           
    }

    void OnMouseDown()
    {
        if(clean == false)
        {
            numofclicks = numofclicks+1;
            if(numofclicks<2)
            {  
                DA_Score.score = DA_Score.score + 1; 
                clean = true;  
                anim.SetBool("red",true);         
                timer = Random.Range(0.5f, 5f);
                targetTime = 4.398f;
                numofclicks = 0;
            }
    
        }
    }
}