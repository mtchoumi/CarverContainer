using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eml_Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 1;
    public static float totalTimer = -5;
    int enemy = 0;
    public static int enemiesHitListPosition = 0;
    bool dontDoAgain = false;
    void Start()
    {
        totalTimer = -5;
        enemiesHitListPosition = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(eml_Sequence.gameOver == false)
        {
            totalTimer+=Time.deltaTime;
            timer-=Time.deltaTime;
        }
        if(timer<0)
        {
            if(totalTimer>0f && totalTimer<5f)
            {
                timer = Random.Range(.1f,.4f);
                enemy = 1;
                transform.position = new Vector2(Random.Range(-2,3)*1.5f-20f, 8f);
                Instantiate(GameObject.Find("EnemyType" + enemy.ToString()), transform.position, Quaternion.identity);
            }
            if(totalTimer>5f && totalTimer<10f)
            {
                timer = Random.Range(.1f,.4f);
                enemy = Random.Range(1, 3);
                transform.position = new Vector2(Random.Range(-2,3)*1.5f-20f, 8f);
                Instantiate(GameObject.Find("EnemyType" + enemy.ToString()), transform.position, Quaternion.identity);
            }
            if(totalTimer>10f && totalTimer<15f)
            {
                timer = Random.Range(.1f,.4f);
                enemy = Random.Range(1, 4);
                transform.position = new Vector2(Random.Range(-2,3)*1.5f-20f, 8f);
                Instantiate(GameObject.Find("EnemyType" + enemy.ToString()), transform.position, Quaternion.identity);
            }
        }
        
        if(totalTimer>20f)
        {
            if(dontDoAgain == false)
            {    
                GameObject newObject;
                dontDoAgain = true;
                for(var i=0; i<enemiesHitListPosition; i++)
                {                
                    newObject = Instantiate(GameObject.Find("enemy"+i.ToString()), new Vector2(5.25f+i, 4f), Quaternion.identity);
                    if(newObject.GetComponent<eml_enemy1>())
                    {
                        newObject.GetComponent<eml_enemy1>().enabled = false;
                    }
                    if(newObject.GetComponent<eml_enemy2>())
                    {
                        newObject.GetComponent<eml_enemy2>().enabled = false;
                        newObject.GetComponent<Animator>().SetInteger("LookingDirection", 2);
                    }
                    if(newObject.GetComponent<eml_enemy3>())
                    {
                        newObject.GetComponent<eml_enemy3>().enabled = false;
                    }
                }
            }
            if(eml_Sequence.gameOver == false)
            {
                GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, new Vector3(0f, 0f, -10f), Time.deltaTime*4f);
            }    
        }
    }
}
