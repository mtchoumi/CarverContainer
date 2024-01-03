using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSQ_HatSpawn : MonoBehaviour
{
    public GameObject Hat;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Random.Range(-9f,9f), 6, 0);
        spawnTimer += Time.deltaTime;
        if(spawnTimer > 4){
            Instantiate(Hat, transform.position, Quaternion.identity);
            spawnTimer = 0;
        }
    }
}

