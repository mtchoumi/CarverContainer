using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMW_CamMove : MonoBehaviour
{
Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         rb.velocity = new Vector3 (0f, 0f, 100f);
    }
}
