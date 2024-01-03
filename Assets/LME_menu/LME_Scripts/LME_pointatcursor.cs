using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LME_pointatcursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
        mousePos.z = 0;
        Vector3 dir = mousePos - transform.position;
        transform.up = dir;
        print(dir);
        if (transform.rotation.eulerAngles.z > 90 && transform.rotation.eulerAngles.z < 270)
        {
            if (dir.x < 0) //left
                transform.rotation = Quaternion.Euler(0,0,90);
            else if (dir.x > 0) //right
                transform.rotation = Quaternion.Euler(0,0,270);
        }
    }
}
