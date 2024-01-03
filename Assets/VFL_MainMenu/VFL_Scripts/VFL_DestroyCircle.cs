using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_DestroyCircle : MonoBehaviour
{
    private float destroyTimer = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(VFL_ButtonSpawn.isSpawned == true){
            destroyTimer += Time.deltaTime;
            if(destroyTimer > 3){
                Destroy(gameObject);
                destroyTimer = 0.0f;
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D col){
        if(col.CompareTag("Player")){
            if(VFL_ButtonSpawn.isSpawned == true){
                if(destroyTimer > 3){
                    VFL_PlayerHealthDisplay.playerHealth -= 50;
                    Destroy(gameObject);
                    destroyTimer = 0.0f;
                }
            }
        }
    }
}
