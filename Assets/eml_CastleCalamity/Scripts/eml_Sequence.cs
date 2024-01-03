using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class eml_Sequence : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject newArrow;
    GameObject currentEnemy;
    int enemyCount = 0;
    public Text timerText;
    public Text endScoreText;
    public Text endTimerText;
    public Text endHealthText;
    public Text endWinText;
    public GameObject bossPicture;
    public GameObject bossText;
    int currentArrow;
    int enemyDifficulty;
    int enemyHealth=3;
    int random;
    int health = 5;
    int maxHealth;
    int bossPoints = 1;
    float damagedTimer = 0;
    float gameTimer = -5f;
    bool dontDoAgain = false;
    int nextSequenceLength;
    public static bool gameOver = false;
    void Start()
    {    
        enemyHealth=3;
        health = 5;
        bossPoints = 1;
        damagedTimer = 0;    
        dontDoAgain = false;
        gameOver = false;
        gameTimer = -5f;
        currentArrow=0;
        health = 5;
        currentEnemy = GameObject.Find(enemyCount.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        if(gameTimer>-1f && gameTimer<3f)
        {
            GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, new Vector3(-20f, 0f, -10f), Time.deltaTime*3f);
        }
        if(gameOver == false && gameTimer>0f)
        {    
            if(Mathf.Floor((35-gameTimer)*10) % 10 == 0)
            {
                timerText.text = Mathf.Floor((35-gameTimer)).ToString() +".0";
            }
            else timerText.text = (Mathf.Floor((35-gameTimer)*10)/10f).ToString();
        }
        if(eml_Spawner.totalTimer>20f)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
            print(GameObject.Find(currentArrow.ToString()).GetComponent<SpriteRenderer>().sprite.ToString());
                if(GameObject.Find(currentArrow.ToString()).GetComponent<SpriteRenderer>().sprite.ToString() == "UpArrow (UnityEngine.Sprite)")
                {
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                }
                else
                {
                    health--;
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                    damagedTimer = 0;
                } 
            }
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(GameObject.Find(currentArrow.ToString()).GetComponent<SpriteRenderer>().sprite.ToString() == "DownArrow (UnityEngine.Sprite)")
                {
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                }
                else
                {
                    health--;
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                    damagedTimer = 0;
                } 
            }
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if(GameObject.Find(currentArrow.ToString()).GetComponent<SpriteRenderer>().sprite.ToString() == "LeftArrow (UnityEngine.Sprite)")
                {
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                }
                else
                {
                    health--;
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                    damagedTimer = 0;
                } 
            }
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(GameObject.Find(currentArrow.ToString()).GetComponent<SpriteRenderer>().sprite.ToString() == "RightArrow (UnityEngine.Sprite)")
                {
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                }
                else
                {
                    health--;
                    Destroy(GameObject.Find(currentArrow.ToString()));
                    currentArrow++;
                    damagedTimer = 0;
                } 
            }
        }
        if(GameObject.Find("Heart" + (health+1).ToString()))
        {
            for(int i = (health+1); i<=5; i++)
            {
                Destroy(GameObject.Find("Heart" + i.ToString()));
            }
        }
        if(damagedTimer<0.1f)
        {
            damagedTimer += Time.deltaTime;
            GameObject.Find("Background").GetComponent<SpriteRenderer>().color = new Color(1f,0f,0f,0.1f);
        }
        else 
        {
            GameObject.Find("Background").GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.1f);
        }
        if(health<1 && gameOver == false)
        {
            health = 0;
            Gameover();
        }
        if(Mathf.Floor((35-gameTimer)*10)<0 && gameOver == false)
        {
            Gameover();
        }
        
        
        if(eml_Spawner.totalTimer>20.1f)
        {
            for(int i = enemyCount; i<eml_Spawner.enemiesHitListPosition; i++)
            {
                if(i == enemyCount)
                {
                    GameObject.Find("enemy" + i.ToString() +"(Clone)").transform.position = Vector2.Lerp(GameObject.Find("enemy" + i.ToString()+ "(Clone)").transform.position, new Vector2(0f, 0f), Time.deltaTime*5f);
                    GameObject.Find("enemy" + i.ToString() +"(Clone)").transform.localScale = Vector3.Lerp(GameObject.Find("enemy" + i.ToString()+ "(Clone)").transform.localScale, new Vector3(3f,3f,1f), Time.deltaTime * 5f);
                }
                else GameObject.Find("enemy" + i.ToString() +"(Clone)").transform.position = Vector2.Lerp(GameObject.Find("enemy" + i.ToString()+ "(Clone)").transform.position, new Vector2(5.25f+i-enemyCount, 4f), Time.deltaTime*5f);
            }
            
            if(dontDoAgain==false)   
            {
                dontDoAgain = true;
                currentArrow=0;
                if(GameObject.Find("enemy" + enemyCount.ToString()))    
                {
                    currentEnemy = GameObject.Find("enemy" + enemyCount.ToString());
                    if(currentEnemy.GetComponent<eml_enemy1>())
                    {
                        enemyHealth = 2;
                    }
                    if(currentEnemy.GetComponent<eml_enemy2>())
                    {
                        enemyHealth = 3;
                    }
                    if(currentEnemy.GetComponent<eml_enemy3>())
                    {
                        enemyHealth = 4;
                    }
                    CreateSequence(enemyHealth);
                }
                else
                {
                    GameObject boss = GameObject.Find("Boss");
                    boss.name = "enemy0";
                    boss.transform.position = new Vector2(0f, .5f);
                    boss.transform.localScale = new Vector2(.6f, .6f);
                    currentEnemy = GameObject.Find("enemy" + enemyCount.ToString());
                    enemyHealth = 20;
                    bossPoints = 10;
                    CreateSequence(enemyHealth);
                    bossPicture.SetActive(true);
                    bossText.SetActive(true);                    
                } 
                
            }
        }
        if(currentArrow>enemyHealth-1)
        {
            currentArrow = 0;
            Destroy(GameObject.Find("enemy" + enemyCount.ToString()));
            Destroy(GameObject.Find("enemy" + enemyCount.ToString() +"(Clone)"));
            enemyCount++;
            if(GameObject.Find("enemy" + enemyCount.ToString()))   
            { 
                currentEnemy = GameObject.Find("enemy" + enemyCount.ToString());
                if(currentEnemy.GetComponent<eml_enemy1>())
                {
                    enemyHealth = 2;
                }
                if(currentEnemy.GetComponent<eml_enemy2>())
                {
                    enemyHealth = 3;
                }
                if(currentEnemy.GetComponent<eml_enemy3>())
                {
                    enemyHealth = 4;
                }
                CreateSequence(enemyHealth);
            }
            else if(gameOver == false)
            {
                Victory();
            }
        }
        if(gameOver == true)
        {
            GameObject.Find("Main Camera").transform.position = Vector3.Lerp(GameObject.Find("Main Camera").transform.position, new Vector3(0f, -100f, -10f), Time.deltaTime*3f);
            if(gameTimer>107f)
            {
                eml_Spawner.totalTimer = -5;
                eml_Spawner.enemiesHitListPosition = 0;
                QuickPlay.nextScene();
            }
        }
    }

    void CreateSequence(int length)
    {
        int[] sequence = new int[length];
        for(int i = 0; i<length; i++)
        {
            sequence[i] = Random.Range(1,5);
            transform.position = new Vector2((((16f/length)*(i+0.5f))-8f),-3f);
            
            if(sequence[i]==1)
            {
                newArrow = Instantiate(GameObject.Find("UpArrow"), transform.position, Quaternion.identity);
            }
            if(sequence[i]==2)
            {
                newArrow = Instantiate(GameObject.Find("RightArrow"), transform.position, Quaternion.identity);
            }
            else if(sequence[i]==3)
            {
                newArrow = Instantiate(GameObject.Find("DownArrow"), transform.position, Quaternion.identity);
            }
            else if(sequence[i]==4)
            {
                newArrow = Instantiate(GameObject.Find("LeftArrow"), transform.position, Quaternion.identity);
            }
            newArrow.name = i.ToString();
        }
        
        transform.position = new Vector2(2f,0f);
    }
    void Gameover()
    {
        gameOver = true;
        print("Gameover");
        if(Mathf.Floor((35-gameTimer)*10)<0f)
        {
            timerText.text = "0.0";
            gameTimer = 35;
        }
        endTimerText.text = Mathf.Floor((35-gameTimer)*10).ToString();
        endScoreText.text = (Mathf.Floor((35-gameTimer)*10)*health*bossPoints).ToString() + " Points";
        endHealthText.text = health.ToString();
        endWinText.text = "You Lose";
        gameTimer = 100;
    }
    void Victory()
    {
        print("Victory");
        gameOver = true;
        endTimerText.text = Mathf.Floor((35-gameTimer)*10).ToString();
        endScoreText.text = (Mathf.Floor((35-gameTimer)*10)*health*bossPoints).ToString() + " Points";
        endHealthText.text = health.ToString();
        gameTimer = 100;
    }
}