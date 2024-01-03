using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BCK_rontayte : MonoBehaviour
{
    public float accel;
    public float interval = 1;
    public static float score = 0;
    public float time = 0f;
    //public float time2 = 30f;
    Rigidbody2D rb;
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      BCK_Display.score = 0;
    }
    void Update()
    {
      time += Time.deltaTime;
      BCK_Display.time2 -= Time.deltaTime;
      if (time >= interval)
      {
        BCK_Display.score++;
      }
      if (BCK_Display.time2 <= 0f)
      {
        SceneManager.LoadScene("BCK_Score");
      }
        // alter point system: depending on how parallel/balanced the ball is on on the pink balancing point, they will recieve more points. Perfectly balanced is 0, as close to 90 degrees without falling is 100. Fil in the numbers in between accordingly, rewarding the points rounded up. This will incentivise the player to take risks to get more points.
        rb.velocity = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
          rb.velocity = new Vector2(-15f, -2f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
          rb.velocity = new Vector2(15f, -2f);
        }
    }
}