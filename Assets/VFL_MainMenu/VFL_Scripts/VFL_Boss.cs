using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_Boss : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D bossRB;
    // Start is called before the first frame update
    void Start()
    {
        bossRB = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.collider.CompareTag("Player Projectiles")){
            Destroy(col.gameObject);
            VFL_HealthDisplay.bossHealth -= 5;
        }
    }
}
