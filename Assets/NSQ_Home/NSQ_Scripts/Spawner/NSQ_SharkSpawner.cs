using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSQ_SharkSpawner : MonoBehaviour
{
    public GameObject Shark;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(12, Random.Range(-4f,2f), 0);
        spawnTimer += Time.deltaTime;
        if(spawnTimer > 5){
            Instantiate(Shark, transform.position, Quaternion.identity);
            spawnTimer = 0;
        }
    }
}
