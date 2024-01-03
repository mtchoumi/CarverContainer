using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDG_CarSpawn : MonoBehaviour
{
     public GameObject prefab;
     public float interval = 1;  
     float time = 0.0f;
     Rigidbody2D rb;
     // GameObject car = GameObject.Find("LDG_Car");
     // GameObject car2 = GameObject.Find("LDG_Car(Clone)");  //Sets the variable ball to the ball GameObject
     void Start()
    {
     // rb = GetComponent<Rigidbody2D>(); 
      //car.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0f); //Sets the velocity of the ball to Vx = 2 and Vy = 2 
     // car2.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0f); //Sets the velocity of the ball to Vx = 2 and Vy = 2
    }
    void Update()
    {
        time += Time.deltaTime; 
        if (time >= interval)
        {
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(-22f, -3.5f),transform.rotation);
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(12f,0f);
            time = 0f; 
        }
    }
}
