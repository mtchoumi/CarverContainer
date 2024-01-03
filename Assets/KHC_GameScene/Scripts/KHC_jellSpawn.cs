using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KHC_jellSpawn : MonoBehaviour
{
    public GameObject jelly;
    const int minJelly = KHC_jelly.minJelly;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("jel").Length < KHC_move.maxJelly * 2 / 3)
        {
            int ranum = Random.Range(1, minJelly);
            for (int i = 0; i < ranum; i++) 
            {
                GameObject jelReference = GameObject.FindWithTag("jel");
                float vectX = jelReference.GetComponent<KHC_jelly>().riverMaxX;
                float vectY = Random.Range(jelReference.GetComponent<KHC_jelly>().riverMinY, jelReference.GetComponent<KHC_jelly>().riverMaxY);
                GameObject newJelly = Instantiate(jelly, new Vector2(vectX, vectY), Quaternion.identity);
                newJelly.GetComponent<Rigidbody2D>().velocity = new Vector2 (jelReference.GetComponent<Rigidbody2D>().velocity.x, Random.Range(-1 * jelly.GetComponent<KHC_jelly>().speedRange, jelly.GetComponent<KHC_jelly>().speedRange));
            }
        }
    }
}