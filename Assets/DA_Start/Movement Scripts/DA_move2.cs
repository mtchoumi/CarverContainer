using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DA_move2 : MonoBehaviour
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
            box9.enabled=false;
            box10.enabled=false;
            box11.enabled=false;
            box12.enabled=false;
            box13.enabled=false;
            box14.enabled=false;
            box15.enabled=false;
            box16.enabled=false; 

            box1.enabled=true;
            box2.enabled=true;
            box3.enabled=true;
            box4.enabled=true;
            box5.enabled=true;
            box6.enabled=true;
            box7.enabled=true;
            box8.enabled=true;
       
        startTime = Time.time;

       
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
         {
            box9.enabled=false;
            box10.enabled=false;
            box11.enabled=false;
            box12.enabled=false;
            box13.enabled=false;
            box14.enabled=false;
            box15.enabled=false;
            box16.enabled=false; 

            box1.enabled=true;
            box2.enabled=true;
            box3.enabled=true;
            box4.enabled=true;
            box5.enabled=true;
            box6.enabled=true;
            box7.enabled=true;
            box8.enabled=true;

        float distCovered = (Time.time - startTime) * speed;

        
        float fractionOfJourney = distCovered / journeyLength;

        
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
         }
    }

}