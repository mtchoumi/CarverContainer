using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_Particles : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
    ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;

Color color = new Color32(9, 251, 122, 128);
settings.startColor = color;
 
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
