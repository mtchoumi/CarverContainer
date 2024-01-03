using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_SlowMaterial : MonoBehaviour
{
    GameObject Player;
    //MJB_PlayerMove MoveScript = Player.GetComponent<MJB_PlayerMove>();
    // Start is called before the first frame update
    void Start()
    {
        Player =  GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            Player.GetComponent<MJB_PlayerMove>().playerSpeed = 3.5f;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
           Player.GetComponent<MJB_PlayerMove>().playerSpeed = Player.GetComponent<MJB_PlayerMove>().playerSpeedOld;
        }
    }
}
