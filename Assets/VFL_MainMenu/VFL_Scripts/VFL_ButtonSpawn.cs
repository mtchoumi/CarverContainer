using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFL_ButtonSpawn : MonoBehaviour
{
    public GameObject warningCircle;
    public GameObject spawnObject;
    public GameObject healthPot;
    GameObject player;
    private float warningTimer = 0.1f;
    private float timer = 0.1f;
    private float healthTimer = 0.1f;
    public static bool isSpawned;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        healthTimer += Time.deltaTime;
        warningTimer += Time.deltaTime;
        timer += Time.deltaTime;
        if (timer > 0)
        {
            if (timer > 7 && timer < 10)
            {
                Instantiate(spawnObject, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5, Quaternion.identity);
                timer = 0f;
            }
        }
        if(warningTimer > 0.0f)
        {
            if(warningTimer > 4.0f && warningTimer < 5f) {
                Instantiate(warningCircle, player.transform.position, Quaternion.identity);
                isSpawned = true;
                warningTimer = 0f;
            }
        }
        if(healthTimer > 0.0f)
        {
            if(healthTimer > 8.0f && healthTimer < 10f)
            {
                Instantiate(healthPot, new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 5, Quaternion.identity);
                healthTimer = 0f;
            }
        }
    }
}
