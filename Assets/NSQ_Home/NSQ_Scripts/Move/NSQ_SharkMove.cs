using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NSQ_SharkMove : MonoBehaviour
{
    public float thrust;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * thrust * Time.deltaTime);
    }
}
