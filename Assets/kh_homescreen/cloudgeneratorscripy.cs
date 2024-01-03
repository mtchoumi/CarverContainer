using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudgeneratorscripy : MonoBehaviour
{
    [SerializeField]
    GameObject[] clouds;

    [SerializeField]
    float spawnInterval;
   
    [SerializeField]
    GameObject endPoint;

    Vector3 startPos;
    

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        Invoke("AttemptSpawn", spawnInterval);
    }

    // Update is called once per frame
    void SpawnCloud()
    {
        int randomIndex = UnityEngine.Random.Range(0,5);
        GameObject cloud = Instantiate(clouds[randomIndex]);


        float startY = UnityEngine.Random.Range(startPos.y - 1f, startPos.y  + 1f);

        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        float scale = UnityEngine.Random.Range(0.8f, 1.2f);
        cloud.transform.localScale = new Vector2(scale,scale);

        float speed = UnityEngine.Random.Range(0.5f, 1.5f);
        cloud.GetComponent<cloudscript>().StartFloating(speed, endPoint.transform.position.x);

    }
    void AttemptSpawn()
    {
        SpawnCloud();
        Invoke("AttemptSpawn", spawnInterval);
    }
}
