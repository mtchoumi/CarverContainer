using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSB_swordmove : MonoBehaviour
{
    public float ran;
    Transform tra;
    // Start is called before the first frame update
    void Start()
    {
        ran = Mathf.Round(Random.Range(0f,3f));
        tra = gameObject.GetComponent<Transform>(); 
        if (ran == 1)
        {
            transform.position = new Vector2(-5.5f, -1.5f);
        }
        if (ran == 2)
        {
            transform.position = new Vector2(6f, -0.75f);
        }
        if (ran == 3)
        {
            transform.position = new Vector2(1f, 0f);
        } 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
