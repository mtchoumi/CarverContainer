using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEC_ItemPickup : MonoBehaviour
{
    public GameObject messageText;
    SpriteRenderer sr;
    string itemType;
    bool held;
    string message = "You got an item!";
    public bool dummy;
    public Sprite dual;
    public Sprite tri;
    public Sprite rapid;
    public Sprite octo;
    int scale = 0;
    float messageTimer;
    // Start is called before the first frame update
    void Start()
    {
        messageText = GameObject.Find("ItemNotif");
        messageTimer = 0;
        scale = Screen.width;
        sr = GetComponent<SpriteRenderer>();
        float newRand = Random.Range(1, 20);
        if (newRand == 3 || newRand == 19 || newRand == 11 || newRand == 12)
        {
            if (newRand == 3)
            {
                sr.sprite = dual;
                itemType = "Dual";
            }
            else if (newRand == 19)
            {
                sr.sprite = tri;
                itemType = "Tri";
            }
            else if (newRand == 11)
            {
                sr.sprite = rapid;
                itemType = "Rapid";
            }
            else if (newRand == 12)
            {
                sr.sprite = octo;
                itemType = "Octo";
            }
        }
        else Destroy(gameObject);
   held = false;
       
        //sr.color = Color.green;
        //gray=128,128,128
        //yellow=255,235,4
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && held)
        {
            messageTimer = 0;
            Destroy(gameObject);
        }
        if (messageTimer > 0)
        {
            messageTimer += -Time.deltaTime;
        }
        else messageText.GetComponent<Text>().text = "";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && held == false)
        {
            SEC_PlayerMove.itemHeld = itemType;
            transform.position = GameObject.Find("PlayerInv").transform.position;
            transform.localScale = new Vector3(0.8f, 0.8f, 1);
            held = true;
            messageTimer = 1;
            messageText.GetComponent<Text>().text = message;
        }
    }
}
