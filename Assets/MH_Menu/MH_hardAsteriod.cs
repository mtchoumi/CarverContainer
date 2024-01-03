using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_hardAsteriod : MonoBehaviour
{
    public float time = 0.0f;
    public float interval = 10;
    public int AI;
       public int AI2;
public float time1 = 0.0f;
    public GameObject asteriod;
    public GameObject SuperAsteriod;

    public GameObject prefab;
    public GameObject prefab1;


    public float timer = 0.0f;
    public float interEnd = 10;

    // Start is called before the first frame update
    void Start()
    {
        asteriod.GetComponent<MH_spawn>().isSpawning = true;
    }

    // Update is called once per frame
     void Update()
    {
        int Stancekill = Random.Range(-9,9);
        int lastNumber = 0;
        AI = Random.Range(-10,11);
        if(AI == lastNumber){
            AI = Random.Range(-10,11);

        }
            /*if(GameObject.Find("charIdle1a").GetComponent<Rigidbody2D>().velocity.x == 0){
     
            AI = Mathf.RoundToInt(GameObject.Find("charIdle1a").transform.position.x - Stancekill);
            
        }else{
        AI = Random.Range(-10,11);
        }*/
        
        lastNumber = AI;
            int lastNumber2 = 0;
        AI2 = Random.Range(-10,11);
        if(AI2 == lastNumber2){
            AI2 = Random.Range(-10,11);

        }
        lastNumber2 = AI2;
timer += Time.deltaTime;
        if(timer >= interEnd && asteriod.GetComponent<MH_spawn>().isSpawning == true){
            GameObject obj = (GameObject)Instantiate(prefab1, new Vector2(AI2,10f),transform.rotation);
            timer = 0.0f;
        }
        time += Time.deltaTime;
        
        if(time >= interval && asteriod.GetComponent<MH_spawn>().isSpawning == true){
             GameObject obj = (GameObject)Instantiate(prefab, new Vector2(AI,10f),transform.rotation);
             time = 0.0f;
        }
        
    }
}
