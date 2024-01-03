using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_ImagineHavingAScriptJustSoYouCanDestroyYourselfPrettyCringe : MonoBehaviour
{
    public float destroyTime;
    public float destroyInterval;
    private float reallyScale;
    // Start is called before the first frame update
    void Start()
    {
        destroyTime = 0.0f;
        destroyInterval = 4;
        reallyScale = 2.3f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject w = GameObject.Find("xLimit Right");
        GGV_TimeDisplay t = w.GetComponent<GGV_TimeDisplay>();
        destroyTime += Time.deltaTime;
        if(destroyTime >= 3)
        {
            transform.localScale = new Vector3(1, reallyScale, 1);
        }
        if(destroyTime >= destroyInterval)
        {
            Destroy(gameObject);
        }
        if(t.hasWon == true)
        {
            Destroy(gameObject);
        }
    }
}
