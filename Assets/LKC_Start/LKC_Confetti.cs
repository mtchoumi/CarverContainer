using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LKC_Confetti : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    //private float timeCount = 0.0f;
    //private float bogus = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bogus += 0.5f; 
        GameObject obj = Instantiate(prefab, new Vector3(Random.Range(-7.91f, 7.94f), 10f, 0f), Quaternion.identity);
        obj.GetComponent<SpriteRenderer>().color=UnityEngine.Random.ColorHSV();
        //Quaternion Target = Quaternion.Euler(0f,0f, 270);
        //obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, Target, timeCount);
        //timeCount = timeCount + Time.deltaTime;

        //obj.transform.rotation = Quaternion.Euler(0f,0f, 0 + bogus);
        
    }
}
