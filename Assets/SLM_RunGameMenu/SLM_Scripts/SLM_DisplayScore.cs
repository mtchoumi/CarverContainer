using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SLM_DisplayScore : MonoBehaviour
{
    private float score;
    [SerializeField] private GameObject prefab;
  //  private Vector3 pos;
  //  private Vector3 pos2;
   // private int spawn = 0;
  //  private int spawn2 = 0;
    private float displayScore=30;
    private Text scoreTxt;
   // Quaternion newQuaternion;
    GameObject spawner;
 /*
    Quaternion Spawn(){
        newQuaternion = newQuaternion.Set(spawner.transform.position.x,spawner.transform.position.y,0,1);
        return newQuaternion;
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GetComponent<Text>();
         int chance = Random.Range(1,4);
         
        if(chance==1){
            spawner = GameObject.Find("RightSpawn");
        }
        else if(chance==2){
            spawner = GameObject.Find("LeftSpawn");
        }
        else if(chance==3){
            spawner = GameObject.Find("TopSpawn");
        }
        else{
            spawner = GameObject.Find("BottomSpawn");
        }
     //  Vector3 spawnObject= new Vector3(spawner.transform.position.x,spawner.transform.position.y,0);
     //  pos.position = (new Vector3(Random.Range(-10f,10f),Random.Range(-10f,10f)));
     //  pos2.position = (new Vector3(Random.Range(-10f,10f),Random.Range(-10f,10f)));
        GameObject Killer = Instantiate(prefab,spawner.transform.position,Quaternion.identity);
        Killer.name = "killer";
        Killer.transform.position = new Vector3(spawner.transform.position.x,spawner.transform.position.y,0);
        
    }
   

    // Update is called once per frame
    void Update()
    {
     //   pos = GameObject.Find("RightSpawn").transform.position;
      //  pos2 = GameObject.Find("BottomSpawn").transform.position;
        score += Time.deltaTime;
        if(score>=1){
        displayScore = (displayScore-1);
        scoreTxt.text = displayScore.ToString();
        score = 0;
        }
        if(displayScore<=0){
            SceneManager.LoadScene("SLM_RunGameWin");
        }
       if(displayScore==25){
           Destroy(GameObject.Find("objectiveTxt"));
       }
        
        
    }
}
