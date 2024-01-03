using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class soo_spawn : MonoBehaviour
{
    public GameObject prefab;
    public static int count;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
     timer = 0.01f;   
count = 0;
    }

    // Update is called once per frame
    void Update()
    {
       timer -= Time.deltaTime;
       if( timer <=0 )
       {
           GameObject obj = Instantiate(prefab, transform.position, Quaternion.identity);
           count += 1;
           timer = Random.Range (1,1.5f);
           obj.transform.position = new Vector3 (Random.Range(Camera.main.orthographicSize * 16/9, -Camera.main.orthographicSize * 16/9 ),Random.Range(Camera.main.orthographicSize, -Camera.main.orthographicSize),0);
       if ( count >=7 )
       {
             SceneManager.LoadScene("soo_gameover");
       }
       }
       
    }

}
