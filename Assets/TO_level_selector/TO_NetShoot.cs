using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TO_NetShoot : MonoBehaviour
{
    Transform t;
    public static bool miss;
    // Start is called before the first frame update
    void Start()
    {
        t = GameObject.Find("player").GetComponent<Transform>();
        miss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > TO_Playermove.distancex + 150)
        {
            Destroy(gameObject);
            miss = true;
        }
        if(TO_Playermove.shots == 3 && miss == true)
        {
            SceneManager.LoadScene("TO_game_over");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "dafish")
        {
            miss = false;
            print("Gottem");
            SceneManager.LoadScene("TO_game_win");
        }
    }
}
