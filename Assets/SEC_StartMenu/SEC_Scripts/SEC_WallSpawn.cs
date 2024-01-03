using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEC_WallSpawn : MonoBehaviour
{
    [SerializeField] GameObject wall;
    float numWallsMake;
    // Start is called before the first frame update
    void Start()
    {
        numWallsMake = Random.Range(1, 5);
        for (int i = 0; i < numWallsMake; i++)
        {
            transform.position = new Vector3(Random.Range(-9f, 9f), Random.Range(-4.5f, 1));
            //1 is a vertical wall, 2 is a horizontal wall
            GameObject newWall;
            newWall = Instantiate(wall, transform.position, Quaternion.identity);
            if (Random.Range(1, 3)==1)
            {
                newWall.transform.localScale = new Vector3(Random.Range(0.1f, 0.75f), Random.Range(1f, 4f), 1);
            }
            else
            {
                newWall.transform.localScale = new Vector3(Random.Range(1f, 4f), Random.Range(0.1f, 0.75f), 1);               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
