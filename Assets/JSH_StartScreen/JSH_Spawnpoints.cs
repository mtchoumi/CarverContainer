using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSH_Spawnpoints : MonoBehaviour
{
    public static bool spawn;
    public GameObject prefab;
    private int Timer = 60;
    // Start is called before the first frame update
    void Start()
    {
        JSH_Spawnpoints.spawn = true;
        if(JSH_objectPoint.rn == int.Parse(gameObject.name))
        {
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer--;
        if(Timer <= 0)
        {
            Timer = 0;
        }
        if(JSH_objectPoint.rn == int.Parse(gameObject.name) && Timer == 0)
        {
            print(JSH_objectPoint.rn);
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Timer = 60;
            // Debug.Break();
        }
    }
}
