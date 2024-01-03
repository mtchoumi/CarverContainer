using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_AcidExplosion : MonoBehaviour
{
   public GameObject HazardAsteriod;
   public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
           
        ps = GetComponent<ParticleSystem>();
        HazardAsteriod.GetComponent<MH_AcidSplash>().check = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(HazardAsteriod.GetComponent<MH_AcidSplash>().check == false){
            ps.Play();
                  ParticleSystem.ShapeModule editableShape = ps.shape;

         editableShape.position = HazardAsteriod.GetComponent<MH_AcidSplash>().contactpoint;

        }
    }
}
