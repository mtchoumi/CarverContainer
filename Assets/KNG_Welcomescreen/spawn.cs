using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour {
    public GameObject prefab = null; //Public variable allows user to set prefab from Unity UI
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            //The next line creates a game object as defined by the prefab.  
            //new Vector(0f, 0f) sets the position of the new object
            //Quaternion.identity sets the rotation of the new object
            GameObject obj = (GameObject)Instantiate(prefab, new Vector2(0f,0f), Quaternion.identity);
        }	
	}
}
