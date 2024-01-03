using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DA_move1 : MonoBehaviour
{
    
    public Transform startMarker;
    public Transform endMarker;
    public BoxCollider2D box1;
    public BoxCollider2D box2;
    public BoxCollider2D box3;
    public BoxCollider2D box4;
    public BoxCollider2D box5;
    public BoxCollider2D box6;
    public BoxCollider2D box7;
    public BoxCollider2D box8;
    public BoxCollider2D box9;
    public BoxCollider2D box10;
    public BoxCollider2D box11;
    public BoxCollider2D box12;
    public BoxCollider2D box13;
    public BoxCollider2D box14;
    public BoxCollider2D box15;
    public BoxCollider2D box16;
  
    public float speed = 1.0F;


    private float startTime;

    private float journeyLength;

    void Start()
    {
        
        startTime = Time.time;
        

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
         {
           box1.enabled=false;
            box2.enabled=false;
            box3.enabled=false;
            box4.enabled=false;
            box5.enabled=false;
            box6.enabled=false;
            box7.enabled=false;
            box8.enabled=false; 

            box9.enabled=true;
            box10.enabled=true;
            box11.enabled=true;
            box12.enabled=true;
            box13.enabled=true;
            box14.enabled=true;
            box15.enabled=true;
            box16.enabled=true; 

        float distCovered = (Time.time - startTime) * speed;

        float fractionOfJourney = distCovered / journeyLength;
        
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
}

    }
}