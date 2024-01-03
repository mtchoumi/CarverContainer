using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KLH_tramp : MonoBehaviour
{
    
   
    bool flipCooldown = false;
    byte bounces = 0;
    short mag;
    [SerializeField] short bounciness;
    [SerializeField] short startingMag;
    GameObject player;
    GameObject scoreText;
    GameObject bounceTxt;
    public static bool play = false;
    public static bool gameEnd = false;
    public static int score = 0;
    bool airtime = false;
    float t = 0;
    float q = 0;

    //bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        mag = startingMag;
        scoreText = GameObject.Find("ScoreTxt");
        bounceTxt = GameObject.Find("bouncesLeft");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.Space)&&KLH_cam.playReady){
            foreach(Rigidbody r in KLH_playerMove.rbs){
                r.useGravity = true;
            }
            play = true;
            KLH_cam.playReady = false;
            scoreText.GetComponent<Text>().enabled = true;
            GameObject.Find("ControlScheme").GetComponent<Image>().enabled = false;
            GameObject.Find("instructions").GetComponent<Image>().enabled = false;
            bounceTxt.GetComponent<Text>().enabled = true;
        }

        
        if(flipCooldown){
            q += Time.deltaTime;
            if(q>=0.5){
                KLH_playerMove.sideFlipTxt.GetComponent<Text>().enabled = false;
                KLH_playerMove.flipTxt.GetComponent<Text>().enabled = false;
                GameObject.Find("flipComboTxt").GetComponent<Text>().enabled = false;
                GameObject.Find("comboNumber").GetComponent<Text>().enabled = false;
                flipCooldown = false;
                //Debug.Log("flips false " + q);
                q = 0;
            }
        }

        if(airtime){
            score++;
        }
        
        //end the game
        if(bounces>=20){
            gameEnd = true;
            play = false;
            GameObject.Find("winner").GetComponent<Image>().enabled = true;
        }

        if(gameEnd){
            t+=Time.deltaTime;
            if(t>=5){
                SceneManager.LoadScene("KLH_Score");
            }
        }

        scoreText.GetComponent<Text>().text = "Score: " + score; 
    }

    void OnCollisionEnter (Collision col) {
        //reset all flip logic
        KLH_playerMove.flipping = false;
        KLH_playerMove.sideFlipping = false;
        KLH_playerMove.flipped = false;
        KLH_playerMove.sideFlipped = false;
        KLH_playerMove.flippingForward = false;
        KLH_playerMove.flippingBackward = false;
        KLH_playerMove.sideFlippingLeft = false;
        KLH_playerMove.sideFlippingRight = false;
        KLH_playerMove.flipCombo = false;
        
        //check if player lands feet first
        if((col.gameObject==GameObject.Find("LeftLeg")||col.gameObject==GameObject.Find("RightLeg"))&&play){
            //check if a flip in progress can count as completed
            if(KLH_playerMove.sideFlipRightReady||KLH_playerMove.sideFlipLeftReady){
                KLH_playerMove.sideFlips++;
                KLH_playerMove.sideFlipTxt.GetComponent<Text>().enabled = true;
                KLH_playerMove.sideFlipTxt.GetComponent<Text>().text = "Cartwheel x" + KLH_playerMove.sideFlips + ": " + KLH_playerMove.sideFlips*250;
                KLH_playerMove.sideFlipPos = 0;
            }
            if(KLH_playerMove.flipForwardReady||KLH_playerMove.flipBackwardReady){
                KLH_playerMove.flips++;
                KLH_playerMove.flipTxt.GetComponent<Text>().enabled = true;
                KLH_playerMove.flipTxt.GetComponent<Text>().text = "Flip x" + KLH_playerMove.flips + ": " + KLH_playerMove.flips*250;
                KLH_playerMove.flipPos = 0;
                GameObject.Find("flipSound").GetComponent<AudioSource>().Play();
            }
            if(KLH_playerMove.roundWorldReady){
                KLH_playerMove.roundWorlds++;
            }
            //hasCollided = true;
            mag+=bounciness;
            foreach(Rigidbody r in KLH_playerMove.rbs){
                r.AddForce(new Vector3(0, mag, 0), ForceMode.Impulse);
            }
            score += (KLH_playerMove.sideFlips+KLH_playerMove.flips) * 250;
            score += KLH_playerMove.roundWorlds*500;
            airtime = true;
            GameObject.Find("bounceSound").GetComponent<AudioSource>().Play();
            bounces++;
            bounceTxt.GetComponent<Text>().text = "Bounces Left: " + (10-(bounces/2));
            flipCooldown = true;
        }else{
            //kills player upon landing
            foreach(Rigidbody r in KLH_playerMove.rbs){
                r.constraints = RigidbodyConstraints.None;
            }
            play = false;
            airtime = false;
            gameEnd = true;
            GameObject.Find("Wipeout").GetComponent<Image>().enabled = true;
            GameObject.Find("menu").GetComponent<AudioSource>().Stop();
            GameObject.Find("deathSound").GetComponent<AudioSource>().Play();
        }
        
        KLH_playerMove.sideFlips = 0;
        KLH_playerMove.flips = 0;
        KLH_playerMove.sideFlipPos = 0;
        KLH_playerMove.flipPos = 0;
        KLH_playerMove.trickCombo = 0;
        KLH_playerMove.roundWorlds = 0;
        KLH_playerMove.sideFlipRightReady = false; 
        KLH_playerMove.sideFlipLeftReady = false;
        KLH_playerMove.flipBackwardReady = false; 
        KLH_playerMove.flipForwardReady = false;
        KLH_playerMove.roundWorldReady = false;
        KLH_playerMove.flipIn = false;
        KLH_playerMove.sideFlipIn = false;
        KLH_playerMove.flipComboIn = false;
        
        //Debug.Log(flipCooldown);
    }
}
