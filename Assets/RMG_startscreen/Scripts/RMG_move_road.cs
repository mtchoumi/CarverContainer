using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMG_move_road : MonoBehaviour
{
    [SerializeField] float interval = 1;
    float time = 0.0f;
    bool hasStarted = false;
    int seconds = 0;
    Rigidbody2D rb;
    // float y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // y = rb.position.y;
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
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                // y -= 2;
                // Debug.Log(y);
                // rb.transform.position = new Vector2(transform.position.x, y);
                rb.velocity = -transform.up * 2;
                //RMG_countdown.timer -= 1;
                // rb.velocity = new Vector2(0f, 0f);
            }
            time = 0f;
        }
    }
}
