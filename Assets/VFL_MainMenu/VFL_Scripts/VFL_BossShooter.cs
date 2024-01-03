using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_BossShooter : MonoBehaviour
{
    GameObject BossSprite;
    //GameObject Player;
    public float shootTimer;
    public float timer = 0.1f;
    public GameObject bossBulletprefab;
    void Start()
    {
        BossSprite = GameObject.Find("Boss");
        //Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //shootTimer += Time.deltaTime;
        if(timer > 0.0f){
            if(timer > 0.5f && timer < 1.5f){
                bossShoot();
                timer = 0.0f;
            }

        }
    }
    void bossShoot(){
        GameObject newBossBullets = Instantiate(bossBulletprefab, transform.position, Quaternion.identity);
         newBossBullets.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1,1f), Random.Range(-1, 1f)).normalized * 8, ForceMode2D.Impulse);
        
    }
    
}

