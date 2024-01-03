using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEP_StrainerCode : MonoBehaviour
{
    SpriteRenderer sr;
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SEP_BowlColliderTest.level == 3)
        {
            sr.sprite = Sprite1;
        }
        if(SEP_BowlColliderTest.level == 4)
        {
            sr.sprite = Sprite2;
        }
        if(SEP_BowlColliderTest.level == 5)
        {
            sr.sprite = Sprite3;
        }
        
    }
}
