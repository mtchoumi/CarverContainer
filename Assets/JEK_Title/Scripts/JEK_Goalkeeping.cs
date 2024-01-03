using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEK_Goalkeeping : MonoBehaviour
{
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        //if (JEK_Game.shot==true)
        //{
            Vector3 relativePos = ball.transform.position - transform.position;
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, Quaternion.LookRotation(relativePos).z);
            print(Quaternion.LookRotation(relativePos).z);
        //}
    }
}
