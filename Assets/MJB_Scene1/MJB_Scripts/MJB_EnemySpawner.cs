using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject BigEnemy;
    public GameObject SpecialEnemy;
    private GameObject Player;
    float timer;
    int layerMask;
    int layerMask2;

    int random;

    // Start is called before the first frame update
    void Start()
    {
        //MJB_TimeScore.map = true;
        timer = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        layerMask = 1 << 9;
        layerMask2 = 1 << 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(MJB_Canvas.isSpawning == true)
        {
            timer += Time.deltaTime;

            if(timer >= 1.2f)
            {
                Vector2 spawnLocation = new Vector2(Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10), Random.Range(Player.transform.position.y - 8, Player.transform.position.y + 8));
                RaycastHit2D hit = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask);
                RaycastHit2D hit2 = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask2);

                while(spawnLocation.x > Player.transform.position.x - 8 && spawnLocation.x < Player.transform.position.x + 8 && spawnLocation.y > Player.transform.position.y - 7 && spawnLocation.y < Player.transform.position.y + 7 || hit.collider != null || hit2.collider != null)
                {
                    spawnLocation = new Vector2(Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10), Random.Range(Player.transform.position.y - 8, Player.transform.position.y + 8));
                    hit = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask);
                    hit2 = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask2);
                }
                transform.position = spawnLocation;
                timer = 0;
                
                if(MJB_Canvas.map == false)
                {
                    random = Random.Range(1, 4);
                    if(random == 1)
                    {
                        Instantiate(BigEnemy, transform.position, Quaternion.identity);
                    } else {
                        Instantiate(Enemy, transform.position, Quaternion.identity);
                    }
                } else {
                    random = Random.Range(1, 7);
                    if(random == 1 || random == 2)
                    {
                        Instantiate(BigEnemy, transform.position, Quaternion.identity);
                    } else if(random == 3) {
                        Instantiate(SpecialEnemy, transform.position, Quaternion.identity);
                    } else {
                        Instantiate(Enemy, transform.position, Quaternion.identity);
                    }
                }
                
            }
        }
        
    }
}
