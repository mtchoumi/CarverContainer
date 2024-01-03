using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WCK_Move : MonoBehaviour
{
	Rigidbody2D rb;
    SpriteRenderer sr;
	float moveSpeed;
	int score, play, oldPlay, hurt;
	WCK_TextUpdate textDisplay;
    Animator anim;
    GameObject blood;
    ParticleSystem bloodParticles;
    float axis, axisY, adjust;
    string[] ANIMATIONS = {"idle", "walk", "walkup", "idleup"};
    // Start is called before the first frame update
    void Start()
    {
		score = 2;
		rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        blood = GameObject.Find("blood");
        bloodParticles = blood.GetComponent<ParticleSystem>();
        bloodParticles.Stop();
		textDisplay = Component.FindObjectOfType<WCK_TextUpdate>();
		anim.Play("idle");
        sr.sortingOrder = 10;
        hurt = -1;
        moveSpeed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        oldPlay = play;
        axis = Input.GetAxis("Horizontal");
        axisY = Input.GetAxis("Vertical");
        transform.position += new Vector3(axis, axisY, 0.0f) * Time.deltaTime * moveSpeed;
        if(Mathf.Abs(axisY) > Mathf.Abs(axis)) {
            play = 2;
        }
        else if(axis != 0.0f) {
            play = 1;
            if(axis < 0.0f) {
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            } else {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        } else {
            if(play == 1) {
                play = 0;
            }
            if(play == 2) {
                play = 3;
            }
        }
        if(play != oldPlay) {
            if(play >= 0 && play < ANIMATIONS.Length) {
                anim.Play(ANIMATIONS[play]);
            }
        }
		/*
	    rb.AddForce(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * Time.deltaTime * moveSpeed, ForceMode2D.Impulse);
		rb.velocity = rb.velocity - Time.deltaTime*3.0f;
		*/
    }

    void FixedUpdate()
    {
        if(hurt >= 0) {
            hurt--;
            if(hurt % 2 == 0) {
                sr.sortingOrder = -100;
            } else {
                sr.sortingOrder = 10;
            }
        }
    }

	public int Score {
        get {
            return score;
        }
        set {
            if(hurt < 0) {
                if(score == value+1) {
                    hurt = 30; // must be even number
                }
                score = value;
                if(value < 0) {
                    WCK_Spawner.difficulty = 0;
                    // if game is not built with "Loading", then load game again.
                    SceneManager.LoadScene("WCK_Menu");
                } 
                if(moveSpeed == 8 && value == 0) {
                    bloodParticles.Play();
                    moveSpeed = 3;
                }
                textDisplay.SetScore(score);
            }
        }
    }
	
	public Vector3 Position {
		get {
			return transform.position;
		}
		set {
			transform.position = value;
		}
	}
}
