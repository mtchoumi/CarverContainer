using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Tilemaps;
public class MH_blocks : MonoBehaviour
{
    public GameObject move;
    public TMP_Text textbox;
    public Sprite spriteTile;
    int reset;
    private int block;
     public int[] blockArray;

     public Tilemap tilemap;
  
    // Start is called before the first frame update
    void Start()
    {
          
  
        //block = move.GetComponent<MH_block>().pressClick2;
           textbox = GetComponent<TMP_Text>();
    }

    


    // Update is called once per frame
   void Update()
    {
         //block = move.GetComponent<MH_block>().pressClick2;

        textbox.text = "Blocks: " + MH_block.pressClick2;
         
        //if(move.GetComponent<MH_movespace>().pressClick >= 20){

//move.GetComponent<MH_movespace>().pressClick =20;
        //}
    }
}
