using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KLH_cam : MonoBehaviour
{
    GameObject head; 
    GameObject foot;
    GameObject target; 
    GameObject player;
    GameObject dLight;
    GameObject lightTarget;
    GameObject controls;
    GameObject instructions;
    [SerializeField] float rotateSpeed; 
    public static bool started = false;
    public static bool playReady = false;
    bool horizontalRotate = true;
    Vector3 offset;   
    Vector3 lastDirection;     
    Vector3 lastLastDirection;
    Vector3 newDirection = Vector3.zero;

    void Start () 
    {
        head = GameObject.Find("Head");
        foot = GameObject.Find("LeftFoot");
        target = GameObject.Find("CameraRotateTarget");
        player = GameObject.FindWithTag("Player");
        offset = transform.position - head.transform.position;
        controls = GameObject.Find("ControlScheme");
        instructions = GameObject.Find("instructions");
        dLight = GameObject.Find("Directional Light");
        lightTarget = GameObject.Find("LightRotateTarget");
        /*transform.rotation = Quaternion.identity;
        dLight.transform.rotation = Quaternion.Euler(45, 30, 0);*/
    }

    void Update () 
    {
        if(started){
            Vector3 lightNewDirection = Vector3.RotateTowards(dLight.transform.forward, lightTarget.transform.position-dLight.transform.position, rotateSpeed * Time.deltaTime, 0);
            dLight.transform.rotation = Quaternion.LookRotation(lightNewDirection);
            if(horizontalRotate){
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, target.transform.position-transform.position, rotateSpeed * Time.deltaTime, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
                if(lastDirection == newDirection){
                    horizontalRotate = false;
                }
                lastDirection = newDirection;
            }else{
                Vector3 newNewDirection = Vector3.RotateTowards(transform.forward, foot.transform.position-transform.position, rotateSpeed * Time.deltaTime, 0);
                transform.rotation = Quaternion.LookRotation(newNewDirection);
                if(lastLastDirection == newNewDirection){
                    started = false;
                    playReady = true;
                    controls.GetComponent<Image>().enabled = true;
                    instructions.GetComponent<Image>().enabled = true;
                }
                lastLastDirection = newNewDirection;
            }
        }
        
        if(KLH_tramp.play){
            transform.position = head.transform.position + offset;
        }

        if(KLH_tramp.gameEnd){
            transform.LookAt(head.transform.position);
        }
    }

    public void Play(){
        started = true;
        GameObject.Find("Button").active = false;
    }
}
