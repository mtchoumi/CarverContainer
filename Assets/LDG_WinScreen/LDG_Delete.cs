using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LDG_Delete : MonoBehaviour
{
void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "wall800by20")  //Checks if object collides with the floor
        {
            Destroy(gameObject); //Destroys the gameObject this script is attached to
        }
        if(col.gameObject.name == "Gendimenico_IMP1_PersonArtMain_0")  //Checks if object collides with the floor
        {
            Destroy(gameObject); //Destroys the gameObject this script is attached to
        }
        //if(col.gameObject.name == "LDG_HailArt" || col.gameObject.name == "LDG_HailArt(Clone)")  //Checks if object collides with the floor
       // {
       //     Destroy(gameObject); //Destroys the gameObject this script is attached to
        if(col.gameObject.name == "LDG_Car")  //Checks if object collides with the floor
        {
            Destroy(gameObject); //Destroys the gameObject this script is attached to
        }
       // }
            
    }
}