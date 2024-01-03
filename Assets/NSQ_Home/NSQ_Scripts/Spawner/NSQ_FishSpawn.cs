using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSQ_FishSpawn : MonoBehaviour
{
    public GameObject Fish;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-12, Random.Range(-4f,2f), 0);
        spawnTimer += Time.deltaTime;
        if(spawnTimer > 1.5){
            Instantiate(Fish, transform.position, Quaternion.identity);
            spawnTimer = 0;
        }
    }
}
