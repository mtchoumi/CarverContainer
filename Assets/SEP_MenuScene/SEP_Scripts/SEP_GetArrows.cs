using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEP_GetArrows : MonoBehaviour
{
     public static GameObject UArrow;
     public static GameObject DArrow;
     public static GameObject LArrow;
     public static GameObject RArrow;
    // Start is called before the first frame update
    void Start()
    {
        UArrow = GameObject.Find("UArrow");
        DArrow = GameObject.Find("DArrow");
        LArrow = GameObject.Find("LArrow");
        RArrow = GameObject.Find("RArrow");
        UArrow.SetActive(false);
        DArrow.SetActive(false);
        LArrow.SetActive(false);
        RArrow.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
