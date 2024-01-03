using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cowsheepcolor : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField]
    GameObject [] cow;

    [SerializeField]
    GameObject [] sheep;




    public GameObject redsheep;
    public GameObject yellowsheep;
    public GameObject greensheep;
    public GameObject bluesheep;
    public GameObject pinksheep;
    public GameObject whitesheep;

    public GameObject redcow;
    public GameObject yellowcow;
    public GameObject greencow;
    public GameObject bluecow;
    public GameObject pinkcow;
    public GameObject whitecow;
    public Text textdisplay;
    // Start is called before the first frame update
    void Start()
    {   
    
    textdisplay = GameObject.Find("text").GetComponent<Text>();
    
    
    
    redsheep = GameObject.Find("red sheep");
    yellowsheep = GameObject.Find("yellow sheep");
    greensheep = GameObject.Find("green sheep");
    bluesheep = GameObject.Find("blue sheep");
    pinksheep = GameObject.Find("pink sheep");
    whitesheep = GameObject.Find("sheep");

    redcow = GameObject.Find("red cow");
    yellowcow = GameObject.Find("yellow cow");
    greencow = GameObject.Find("green cow");
    bluecow = GameObject.Find("blue cow");
    pinkcow = GameObject.Find("pink cow");
    whitecow= GameObject.Find("cow");
       
       
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        int randomIndex = Random.Range(0,6);
        int randomIndexx = UnityEngine.Random.Range(0,5);
        int randomIndex1 = UnityEngine.Random.Range(0,5);
        int randomIndex2 = UnityEngine.Random.Range(0,5);
        int randomIndex3 = UnityEngine.Random.Range(0,5);
        int randomIndex4 = UnityEngine.Random.Range(0,5);
        int randomIndex5 = UnityEngine.Random.Range(0,5);
        int randomIndex6 = UnityEngine.Random.Range(0,5);

        float cowx = Random.Range(-8f,8f);
        float cowy = Random.Range(-4f,4f);
        float cowx1 = Random.Range(-8f,8f);
        float cowy1 = Random.Range(-4f,4f);
        float cowx2 = Random.Range(-8f,8f);
        float cowy2 = Random.Range(-4f,4f);
        float sheepx = Random.Range(-8f,8f);
        float sheepy = Random.Range(-4f,4f);
        float sheepx1 = Random.Range(-8f,8f);
        float sheepy1 = Random.Range(-4f,4f);
        float sheepx2 = Random.Range(-8f,8f);
        float sheepy2 = Random.Range(-4f,4f);
        float redy2 = Random.Range(-4f,4f);
        float redx2 = Random.Range(-8f,8f);
        float yellowy2 = Random.Range(-4f,4f);
        float yellowx2 = Random.Range(-8f,8f);
        float greeny2 = Random.Range(-4f,4f);
        float greenx2 = Random.Range(-8f,8f);
        float bluey2 = Random.Range(-4f,4f);
        float bluex2 = Random.Range(-8f,8f);
        float pinky2 = Random.Range(-4f,4f);
        float pinkx2 = Random.Range(-8f,8f);
        float redy = Random.Range(-4f,4f);
        float redx = Random.Range(-8f,8f);
        float yellowy = Random.Range(-4f,4f);
        float yellowx = Random.Range(-8f,8f);
        float greeny = Random.Range(-4f,4f);
        float greenx = Random.Range(-8f,8f);
        float bluey = Random.Range(-4f,4f);
        float bluex = Random.Range(-8f,8f);
        float pinky = Random.Range(-4f,4f);
        float pinkx = Random.Range(-8f,8f);
    
        GameObject cowobj = (GameObject)Instantiate(cow[randomIndexx], new Vector2(cowx,cowy), Quaternion.identity);
        GameObject cowobj1 = (GameObject)Instantiate(cow[randomIndex1], new Vector2(cowx1,cowy1), Quaternion.identity);
        GameObject cowobj2 = (GameObject)Instantiate(cow[randomIndex2], new Vector2(cowx2,cowy2), Quaternion.identity);
        GameObject sheepobj = (GameObject)Instantiate(sheep[randomIndex3], new Vector2(sheepx,sheepy), Quaternion.identity);
        GameObject sheepobj1= (GameObject)Instantiate(sheep[randomIndex4], new Vector2(sheepx1,sheepy1), Quaternion.identity);
        GameObject sheepobj2 = (GameObject)Instantiate(sheep[randomIndex5], new Vector2(sheepx2,sheepy2), Quaternion.identity);
        GameObject red = (GameObject)Instantiate(sheep[0], new Vector2(redx,redy), Quaternion.identity);
        GameObject yellow = (GameObject)Instantiate(sheep[1], new Vector2(yellowx,yellowy), Quaternion.identity);
        GameObject blue = (GameObject)Instantiate(sheep[2], new Vector2(bluex,bluey), Quaternion.identity);
        GameObject green = (GameObject)Instantiate(sheep[3], new Vector2(greenx,greeny), Quaternion.identity);
        GameObject pink = (GameObject)Instantiate(sheep[4], new Vector2(pinkx,pinky), Quaternion.identity);
        GameObject red2 = (GameObject)Instantiate(cow[0], new Vector2(redx2,redy2), Quaternion.identity);
        GameObject yellow2 = (GameObject)Instantiate(cow[1], new Vector2(yellowx2,yellowy2), Quaternion.identity);
        GameObject blue2 = (GameObject)Instantiate(cow[2], new Vector2(bluex2,bluey2), Quaternion.identity);
        GameObject green2 = (GameObject)Instantiate(cow[3], new Vector2(greenx2,greeny2), Quaternion.identity);
        GameObject pink2 = (GameObject)Instantiate(cow[4], new Vector2(pinkx2,pinky2), Quaternion.identity);
       
}

    void Update()
    {
    }

    void OnMouseDown()
    {

        print("hi");
        if(textdisplay.GetComponent<Text>().color != redcow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("game over");
        }
        if(textdisplay.GetComponent<Text>().color == redcow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
        if(textdisplay.GetComponent<Text>().color != yellowcow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("game over");
        }
        if(textdisplay.GetComponent<Text>().color == yellowcow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
        if(textdisplay.GetComponent<Text>().color != greencow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("game over");
        }
        if(textdisplay.GetComponent<Text>().color == greencow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
        if(textdisplay.GetComponent<Text>().color != bluecow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("game over");
        }
        if(textdisplay.GetComponent<Text>().color == bluecow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
        if(textdisplay.GetComponent<Text>().color != pinkcow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("game over");
        }
        if(textdisplay.GetComponent<Text>().color == pinkcow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
        if(textdisplay.GetComponent<Text>().color != whitecow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
        if(textdisplay.GetComponent<Text>().color == whitecow.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
         if(textdisplay.GetComponent<Text>().color == redsheep.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
         if(textdisplay.GetComponent<Text>().color == yellowsheep.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
         if(textdisplay.GetComponent<Text>().color == greensheep.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
         if(textdisplay.GetComponent<Text>().color == bluesheep.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
         if(textdisplay.GetComponent<Text>().color == pinksheep.GetComponent<SpriteRenderer>().color)
       {
            SceneManager.LoadScene("found");
        }
        if(textdisplay.GetComponent<Text>().color == whitesheep.GetComponent<SpriteRenderer>().color)
        {
            SceneManager.LoadScene("found");
        }
    }
}
