using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KLH_playerMove : MonoBehaviour
{
    [SerializeField] int flipSpeed;
    public static List<Rigidbody> rbs;
    List<Transform> joints;
    GameObject player;
    GameObject rotator;
    GameObject comboTxt;
    public static int sideFlips = 0;
    public static int flips = 0;
    public static int roundWorlds = 0;
    public static bool flipping = false;
    public static bool sideFlipping = false;
    public static bool flipped = false;
    public static bool sideFlipped = false;
    public static bool flippingForward = false;
    public static bool flippingBackward = false;
    public static bool flipForwardReady = false;
    public static bool flipBackwardReady = false;
    public static bool sideFlippingLeft = false;
    public static bool sideFlippingRight = false;
    public static bool sideFlipRightReady = false;
    public static bool sideFlipLeftReady = false;
    public static bool roundWorldReady = false;
    public static bool flipCombo = false;
    public static bool flipIn = false;
    public static bool flipComboIn = false;    
    public static bool sideFlipIn = false;
    public static int trickCombo = 0;
    public static float sideFlipStartPos;
    public static float flipStartPos;
    public static float sideFlipPos = 0;
    public static float flipPos = 0;
    public static GameObject sideFlipTxt;
    public static GameObject flipTxt;
    public static GameObject comboNumber;

    // Start is called before the first frame update
    void Start()
    {
        joints = new List<Transform>();
        rbs = new List<Rigidbody>();
        rotator = GameObject.Find("PlayerRotator");
        player = GameObject.FindWithTag("Player");
        AddPartsWithTag(transform, "Generic 1", joints);
        foreach(Transform i in joints){
            rbs.Add(i.gameObject.GetComponent<Rigidbody>());
        }
        sideFlipTxt = GameObject.Find("SideflipTxt");
        flipTxt = GameObject.Find("FlipTxt");
        comboTxt = GameObject.Find("flipComboTxt");
        comboNumber = GameObject.Find("comboNumber");
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        //rotate player and check flips 
        if(KLH_tramp.play){
            if(Input.GetKey(KeyCode.W)){
                float a = 0;
                if(sideFlipping){
                    a += Mathf.Pow(flipSpeed, 2);
                }
                flipPos+=Mathf.Sqrt(Mathf.Pow(flipSpeed, 2)+a);
                if(!flippingForward&&!flippingBackward){
                    flippingForward = true;
                    flipping = true;
                }

                player.transform.RotateAround(rotator.transform.position, Vector3.right, flipSpeed);

            }else if (Input.GetKey(KeyCode.S)){
                float a = 0;
                if(sideFlipping){
                    a += Mathf.Pow(flipSpeed, 2);
                }
                flipPos-=Mathf.Sqrt(Mathf.Pow(flipSpeed, 2)+a);
                if(!flippingForward&&!flippingBackward){
                    flippingBackward = true;
                    flipping = true;
                }
                
                player.transform.RotateAround(rotator.transform.position, Vector3.left, flipSpeed);
            }
            
            if(Input.GetKey(KeyCode.A)){
                float a = 0;
                if(flipping){
                    a += Mathf.Pow(flipSpeed, 2);
                }
                sideFlipPos-=Mathf.Sqrt(Mathf.Pow(flipSpeed, 2)+a);
               //Debug.Log(sideFlipPos);
                if(!sideFlippingLeft&&!sideFlippingRight){
                    sideFlippingLeft = true;
                    sideFlipping = true;
                }

                player.transform.RotateAround(rotator.transform.position, Vector3.forward, flipSpeed);

            }else if (Input.GetKey(KeyCode.D)){
                float a = 0;
                if(flipping){
                    a += Mathf.Pow(flipSpeed, 2);
                }
                sideFlipPos+=Mathf.Sqrt(Mathf.Pow(flipSpeed, 2)+a);
                //Debug.Log(sideFlipPos);
                if(!sideFlippingLeft&&!sideFlippingRight){
                    sideFlippingRight = true;
                    sideFlipping = true;
                }

                player.transform.RotateAround(rotator.transform.position, Vector3.back, flipSpeed);
            }

            //checks if flips/sideflips can count as completed upon landing
            if(sideFlippingLeft){
                if(sideFlipPos<-180){
                    sideFlipLeftReady = true;
                    if(flipForwardReady||flipBackwardReady){
                        roundWorldReady = true;
                    }
                }else if(sideFlipPos>-180){
                    sideFlipLeftReady = false;
                    roundWorldReady = false;
                }
            }else if(sideFlippingRight){
                if(sideFlipPos>180){
                    sideFlipRightReady = true;
                    if(flipForwardReady||flipBackwardReady){
                        roundWorldReady = true;
                    }
                }else if(sideFlipPos<180){
                    sideFlipRightReady = false;
                    roundWorldReady = false;
                }
            }
            if(flippingBackward){
                if(flipPos<-180){
                    flipBackwardReady = true;
                    if(sideFlipRightReady||sideFlipLeftReady){
                        roundWorldReady = true;
                    }
                }else if(flipPos>-180){
                    flipBackwardReady = false;
                    roundWorldReady = false;
                }
            }else if(flippingForward){
                if(flipPos>180){
                    flipForwardReady = true;
                    if(sideFlipRightReady||sideFlipLeftReady){
                        roundWorldReady = true;
                    }
                }else if(flipPos<180){
                    flipForwardReady = false;
                    roundWorldReady = false;
                }
            }

            //checks if sideflip has been completed
            if(sideFlipPos>=360||sideFlipPos<=-360){
                if(flipped){
                    flipCombo = true;
                    if(sideFlips==0){
                        sideFlipTxt.GetComponent<Text>().enabled = false;
                    }
                    comboTxt.GetComponent<Text>().enabled = true;
                    roundWorlds++;
                    comboTxt.GetComponent<Text>().text = "Around the world x" + roundWorlds + ": " + roundWorlds*500;
                    GameObject.Find("roundWorld").GetComponent<AudioSource>().Play();
                }else{
                    sideFlipped = true;
                    sideFlips++;
                    sideFlipTxt.GetComponent<Text>().enabled = true;
                    sideFlipTxt.GetComponent<Text>().text = "Cartwheel x" + sideFlips + ": " + sideFlips*250;
                    GameObject.Find("cartwheel").GetComponent<AudioSource>().Play();
                }
                sideFlipPos = 0;
            }

            //checks if flip has been completed
            if(flipPos<=-360||flipPos>=360){
                if(sideFlipped){
                    flipCombo = true;
                    if(flips==0){
                        flipTxt.GetComponent<Text>().enabled = false;
                    }
                    roundWorlds++;
                    comboTxt.GetComponent<Text>().enabled = true;
                    comboTxt.GetComponent<Text>().text = "Around the world x" + roundWorlds + ": " + roundWorlds*500;
                    GameObject.Find("roundWorld").GetComponent<AudioSource>().Play();
                }else{
                    flipped = true;
                    flips++;
                    flipTxt.GetComponent<Text>().enabled = true;
                    flipTxt.GetComponent<Text>().text = "Flip x" + flips + ": " + flips*250; 
                    GameObject.Find("flipSound").GetComponent<AudioSource>().Play();
                }
                flipPos = 0;
            }

            if(flipped&&!flipIn){
                trickCombo++;
                flipIn = true;
            }
            if(sideFlipped&&!sideFlipIn){
                trickCombo++;
                sideFlipIn = true;
            }
            if(flipCombo&&!flipComboIn){
                trickCombo++;
                flipComboIn = true;
            }
            if(trickCombo>1){
                comboNumber.GetComponent<Text>().enabled = true;
                comboNumber.GetComponent<Text>().text = "Combo x"+trickCombo;
            }
        }
    }

    void AddPartsWithTag(Transform t, string tag, List<Transform> list){
        foreach (Transform child in t){
            if (child.CompareTag(tag)){
                list.Add(child);
            }
            AddPartsWithTag(child, tag, list);
        }
    }
}
