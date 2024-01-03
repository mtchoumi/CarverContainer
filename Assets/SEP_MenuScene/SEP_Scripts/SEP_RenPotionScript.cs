using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEP_RenPotionScript : MonoBehaviour
{
    private Animator anim;
    public static bool AniThing = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SEP_BowlColliderTest.level == 3)
        {
           anim.SetBool("isLevelOne", true);
        }
        if(SEP_BowlColliderTest.level == 4)
        {
           anim.SetBool("isLevelTwo", true);
        }
        if(SEP_BowlColliderTest.level == 5)
        {
           anim.SetBool("isLevelThree", true);
           AniThing = true;
           SEP_BowlColliderTest.timer7 += Time.deltaTime;
        }
    }
}
