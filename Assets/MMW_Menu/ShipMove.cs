using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShipMove : MonoBehaviour
{
	Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
	GameObject Bullet = GameObject.Find("Bullet");
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
    void OnCollisionEnter(Collision col)
{
	if(col.gameObject.name == "Bullet(Clone)")
        {
	    SceneManager.LoadScene("MMW_Menu");
	}
}
}
