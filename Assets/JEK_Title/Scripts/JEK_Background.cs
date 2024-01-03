using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JEK_Background : MonoBehaviour
{
    new public Camera camera;
    int red, green, blue;
    int stage;
    // Start is called before the first frame update
    void Start()
    {
        red = Random.Range(0,255);
        green = Random.Range(0, 255);
        blue = Random.Range(0, 255);
        stage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stage==0)
        {
            red++;
            green--;
            blue--;
            if (red > 255 || green < 0 || blue < 0)
            {
                stage++;
            }
        }
        if (stage==1)
        {
            blue++;
            green++;
            red--;
            if (green > 255 || blue > 255 || red < 0)
            {
                stage++;
            }
        }
        if (stage==2)
        {
            if (blue < 255)
            {
                blue++;
            } else
            {
                stage++;
            }
            if (green < 255)
            {
                green++;
            } else
            {
                stage++;
            }
            red++;
        }
        if (stage == 3)
        {
            if (blue > 0)
            {
                blue--;
            }
            else
            {
                stage = 0;
            }
            if (green < 0)
            {
                green++;
            }
            else
            {
                stage = 0;
            }
            red--;
        }
        camera.backgroundColor = new Color(red/255f, green/255f, blue/255f);
    }
}
