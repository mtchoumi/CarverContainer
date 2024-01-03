using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NK_Spawner : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject Asteroid;
    private float spawnTimer;
    public float gameClock;
    public float torque;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnTimer = 0;
        // rb.velocity = new Vector2(5f,0f);
        gameClock = 0;
    }
    void Update()
    {

        transform.position = new Vector2(11f, Random.Range(-6,5));
        spawnTimer +=Time.deltaTime;
        gameClock +=Time.deltaTime;
        
        if(spawnTimer > .5){
            GameObject obj =Instantiate(Asteroid, transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(-Vector2.right*5f,ForceMode2D.Impulse);
            spawnTimer = 0;
            obj.GetComponent<Rigidbody2D>().AddTorque(100);
            if (gameClock >= 10){
           obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f,0f);
            }
            if (gameClock >= 30){
            obj.GetComponent<Rigidbody2D>().velocity = new Vector2(-15f,0f);
        }
        }
    }
    // void FixedUpdate()
    // {
    //     float turn = Input.GetAxis("Horizontal");
    //     rb.AddTorque(transform.up * torque * turn);
    // }
    //AddForce(-Vector2.right*10f,ForceMode2D.Impulse);
}