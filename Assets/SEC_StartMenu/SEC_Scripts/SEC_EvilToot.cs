using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEC_EvilToot : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 newDir = transform.position - player.transform.position;
        //transform.position.up = newDir;
        //rb.velocity = new Vector3(transform.position.up, 4);
    }
}
