using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGV_TimeDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    private bool summoned = false;
    
    [SerializeField]private float topLocation = 20f;
    public static float Timer = 30.00f;
    private float timePast = 1.00f;
    private float time4 = 0.0f;
    private float interval4 = 5f;
    private float timePassing;
    public bool hasWon = false;
    void Start()
    {
        Timer = 30.00f;
    }
    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.alignment = TextAnchor.MiddleRight;
        GUI.BeginGroup(new Rect(Screen.width/2 - 1, topLocation, 400, 50));
        gs.normal.textColor = Color.white;
        gs.fontSize = 20;
        if(Timer >= 10)
        {
        GUI.Box(new Rect(0, 0, 400, 25), "00:" + Timer, gs);
        } else if (Timer <= 9)
        {
            GUI.Box(new Rect(0, 0, 400, 25), "00:0" + Timer, gs);
        }
        GUI.EndGroup();
    }
    void Update()
    {
        GameObject c = GameObject.Find("Circle");
        GGV_Bounce b = c.GetComponent<GGV_Bounce>();
        // if (GameObject.Find("Circle").GetComponent<GGV_Bounce>().gameOver == false)
        // {
            if(Timer >= 1.00f)
            {
                timePassing += Time.deltaTime;
                if(timePassing >= timePast)
                {
                    Timer -= 1;
                    timePassing = 0;
                }
            }
            if(Timer == 0)
            {
                hasWon = true;
                if (summoned == false)
                {
                    if(b.gameOver == false)
                    {
                GameObject obj = (GameObject)Instantiate(prefab, new Vector2(0, 0), Quaternion.Euler(0, 0, 0));
                summoned = true;
                    }
                }
                time4 += Time.deltaTime;
                if (time4 >= interval4)
                {
                    time4 = 0.0f;

                }
            }
        // }
    }
}
