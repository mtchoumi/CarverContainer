using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMG_Spawner : MonoBehaviour
{
    [SerializeField] private GameObject roadLinePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject roadSpikePrefab;
    [SerializeField] private GameObject roadBoarderPrefab;
    [SerializeField] float interval = 1;
    float time = 0.0f;
    bool hasStarted = false;
    int seconds = 0;
    float position1;
    float position2;
    bool roadSpikes = false;
    //x position for coins
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= interval)
        {
            if(seconds >= 0 && seconds <= 3)
            {
                seconds++;
                if(seconds == 3)
                {
                    hasStarted = true;
                }
            }
            if(hasStarted)
            {
                position1 = Random.Range(6f, -6f);
                GameObject roadLine = (GameObject)Instantiate(roadLinePrefab, new Vector2(0f, 8.5f), Quaternion.identity);
                roadLine.GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                //obj.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GameObject coin = (GameObject)Instantiate(coinPrefab, new Vector2(position1, 8.5f), Quaternion.identity);
                coin.GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                position2 = Random.Range(6f, -6f);
                GameObject leftRoadBoarder = (GameObject)Instantiate(roadBoarderPrefab, new Vector2(7.3f, 9f), Quaternion.identity);
                leftRoadBoarder.GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                GameObject rightRoadBoarder = (GameObject)Instantiate(roadBoarderPrefab, new Vector2(-7.2f, 9f), Quaternion.identity);
                rightRoadBoarder.GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                if(roadSpikes)
                {
                    GameObject roadSpike = (GameObject)Instantiate(roadSpikePrefab, new Vector2(position2, 8.5f), Quaternion.identity);
                    roadSpike.GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                    leftRoadBoarder.GetComponent<SpriteRenderer>().color = Color.white;
                    rightRoadBoarder.GetComponent<SpriteRenderer>().color = Color.white;
                    roadSpikes = false;
                }
                else
                {
                    leftRoadBoarder.GetComponent<SpriteRenderer>().color = Color.red;
                    rightRoadBoarder.GetComponent<SpriteRenderer>().color = Color.red;
                    roadSpikes = true;
                }
                if(GameObject.Find("red_car") != null)
                {
                    GameObject.Find("red_car").GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                }
                if(GameObject.Find("green_car") != null)
                {
                    GameObject.Find("green_car").GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                }
                if(GameObject.Find("pink_car") != null)
                {
                    GameObject.Find("pink_car").GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                }
                if(GameObject.Find("purple_car") != null)
                {
                    GameObject.Find("purple_car").GetComponent<Rigidbody2D>().velocity = -transform.up * 2;
                }
                
            }
            time = 0f;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(gameObject.name.Contains("coin"))
        {
            if(col.gameObject.name.Contains("roadSpike"))
            {
                position2 = Random.Range(6f, -6f);
            }
        }
    }
}
