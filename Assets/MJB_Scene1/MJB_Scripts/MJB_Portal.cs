using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_Portal : MonoBehaviour
{
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);

            GameObject.Find("Player").transform.position = new Vector2(212.955f, -23.76f);
            cam.transform.position = new Vector2(212.955f, -23.76f);
            MJB_Canvas.map = true;

            GameObject.Find("Player").GetComponent<SpriteRenderer>().color = new Color(0.1938412f, 0.3277462f, 0.9339623f, 1); //738AF1
            cam.backgroundColor = new Color(0.7169812f, 0.4314435f, 0.1758633f, 1); //B76E2D

            MJB_Canvas.isSpawning = true;

            GameObject.Find("Main Camera").transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.2078431f, 0.2627451f, 0.7843137f); //3543C8
        }
    }
}
