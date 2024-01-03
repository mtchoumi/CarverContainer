using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ABS_Portal : MonoBehaviour
{
    Animator anim;
    float dtimer;
    [SerializeField]AnimationClip unlockingclip;
    public static string test;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("unlock", false);
        anim.SetBool("unlocked", false);
    }

    void Update()
    {
        dtimer -= Time.deltaTime;
        if (ABS_coin.coins == 3)
        {
            anim.SetBool("unlock", true);
            dtimer = unlockingclip.length; 
        }

        if (dtimer < 0)
        {
            anim.SetBool("unlocked", true);
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.name == "player")
        {
            if (ABS_coin.coins == 3)
            {
                SceneManager.LoadScene("ABS_no");
                test = "done";
            }
        }
    }
}