using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEK_Clouds : MonoBehaviour
{
    Vector3 change;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        float randomism = Random.Range(-1f,1f);
        if (randomism>0) {
            change = new Vector3(0.05f, 0, 0);
        } else {
            change = new Vector3(-0.05f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>Random.Range(3f,8f)) {
            change *= -1f;
            timer = 0;
        }
        transform.position += change;
    }
}
