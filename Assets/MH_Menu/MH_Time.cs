using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MH_Time : MonoBehaviour
{
    public GameObject InfiniteAsteriodSpawner;
    public TMP_Text textbox;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        textbox = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        textbox.text = "Time: " + timer;
    }
}
