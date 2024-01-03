using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GGV_L : MonoBehaviour
{
    public GameObject prefab;
    private float time5 = 0.0f;
    private float interval5 = 1.25f;
    private bool spawned = false;
    public bool work = false;
    private bool killed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
        time5 = 0.0f;
        work = false;
        killed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(killed == false){
        GameObject c = GameObject.Find("Circle");
        GGV_Bounce b = c.GetComponent<GGV_Bounce>();
        }

        if (work == true)
        {
            if(spawned == false)
            {
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
            spawned = true;
            }
            if (killed == false)
            {
                time5 += Time.deltaTime;
            }
            if(time5 >= interval5)
            {
                Destroy(GameObject.Find("Circle"));
                killed = true;
            }
        }
    }
}
