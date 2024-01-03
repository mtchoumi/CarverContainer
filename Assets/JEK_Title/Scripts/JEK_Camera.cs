using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEK_Camera : MonoBehaviour
{
    GameObject theBall;
    Vector3 starting;
    // Start is called before the first frame update
    void Start()
    {
        theBall = GameObject.Find("Ball");
        starting = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (JEK_Game.level < 5 || JEK_Game.shot == true) {
            transform.position = theBall.transform.position;
            transform.position -= new Vector3(0, -9.06f, 23);
        } else if (JEK_Game.shot==false) {
            transform.position = starting;
        }
        if (transform.position.x>-5f) {

        }
    }
}
