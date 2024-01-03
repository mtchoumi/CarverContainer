using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLM_FollowKiller : MonoBehaviour
{
    private Transform killer;
    [SerializeField] private float speed;
   // Vector3 up = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      if(killer==null){
        killer = GameObject.Find("killer").transform;
      }
      transform.up= killer.position - transform.position;
      /*
      Vector3 relativePos = killer.position.z - transform.position.z;
      Quaternion rotation = Quaternion.LookRotation(relativePos);
      Quaternion current = transform.rotation;
      transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime *speed);
      */
      //  transform.LookAt(killer.worldUp);
    //  up=new Vector3(killer.transform.position.x,killer.transform.position.y,0);
      
    }
}
