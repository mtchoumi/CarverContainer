using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RMG_car : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private string playerInputV;
    [SerializeField] private string playerInputH;
    private GameObject redCar;
    float vx;
    float vy;
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        redCar = GameObject.Find("red_car");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameObject.Find("GameObject") == null)
        {
            rb.velocity = new Vector2(vx, vy);
            if(redCar != null)
            {
                GameObject.Find("red_body_score").GetComponent<Transform>().position = redCar.GetComponent<Transform>().position;
            }
            else
            {
                Destroy(GameObject.Find("red_body_score"));
            }
            if(GameObject.Find("green_car") != null)
            {
                GameObject.Find("green_body_score").GetComponent<Transform>().position = GameObject.Find("green_car").GetComponent<Transform>().position;
            }
            else
            {
                Destroy(GameObject.Find("green_body_score"));
            }
            if(GameObject.Find("pink_car") != null)
            {
                GameObject.Find("pink_body_score").GetComponent<Transform>().position = GameObject.Find("pink_car").GetComponent<Transform>().position;                
            }
            else
            {
                Destroy(GameObject.Find("pink_body_score"));
            }
            if(GameObject.Find("purple_car") != null)
            {
                GameObject.Find("purple_body_score").GetComponent<Transform>().position = GameObject.Find("purple_car").GetComponent<Transform>().position;                
            }
            else
            {
                Destroy(GameObject.Find("purple_body_score"));
            }
            if(Input.GetAxis(playerInputV)!=0)
            {
                //rb.velocity = new Vector2(0f, Input.GetAxis(playerInputV) * 2f);
                vy = Input.GetAxis(playerInputV) * speed;
            }
            if(Input.GetAxis(playerInputH)!=0)
            {
                //rb.velocity = new Vector2(Input.GetAxis(playerInputH) * 2f, 0f);
                vx = Input.GetAxis(playerInputH) * speed;
            }
            vy = Input.GetAxis(playerInputV) * speed-2;
            
        }
        
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.name.Contains("coin"))
        {
            if(gameObject.name == "red_car")
            {
                RMG_leaderboard.red_car_score++;
            }
            if(gameObject.name == "green_car")
            {
                RMG_leaderboard.green_car_score++;
            }
            if(gameObject.name == "pink_car")
            {
                RMG_leaderboard.pink_car_score++;
            }
            if(gameObject.name == "purple_car")
            {
                RMG_leaderboard.purple_car_score++;
            }
            Destroy(obj.gameObject);
            //speed++;
        }
        if(obj.gameObject.name.Contains("road_spikes"))
        {
            speed = speed/2;
        }
    }

    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     if(col.gameObject.name.Contains("road spikes"))
    //     {
    //         if(gameObject.name == "red_car")
    //         {
    //             Destroy(GameObject.Find("red_body_score"));
    //         }
    //         if(gameObject.name == "green_car")
    //         {
    //             Destroy(GameObject.Find("green_body_score"));
    //         }
    //         if(gameObject.name == "pink_car")
    //         {
    //             Destroy(GameObject.Find("pink_body_score"));
    //         }
    //         if(gameObject.name == "purple_car")
    //         {
    //             Destroy(GameObject.Find("purple_body_score"));
    //         }
    //         Destroy(gameObject);
    //     }
    // }
}
