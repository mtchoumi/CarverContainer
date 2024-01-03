using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TO_shotscript4 : MonoBehaviour
{
    Renderer re;
    // Start is called before the first frame update
    void Start()
    {
        re = GetComponent<Renderer>();
        re.enabled = false;
        TO_Playermove.shots = 0;
        TO_NetShoot.miss = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TO_Playermove.shots == 3)
        {
            re.enabled = true;
        }
    }
}
