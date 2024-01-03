using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMove : MonoBehaviour
{
	Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
	 rb.velocity = new Vector3(0f, 0f, 100f);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(10f, 0f, 100f);
	}
	if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-10f, 0f, 100f);
	}
  	if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(0f, 10f, 100f);
	}
	if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector3(0f, -10f, 100f);
	}
    }
}
