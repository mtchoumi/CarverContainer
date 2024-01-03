using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class JEK_Fans : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float timer;
    bool jumped;
    NavMeshAgent theNav;
    GameObject kicker;
    GameObject head;
    GameObject ball;
    Transform kickerPosition;
    Rigidbody headBody;
    void Start()
    {
        float randomism = Random.Range(-1f,1f);
        rb = GetComponent<Rigidbody>();
        theNav = GetComponent<NavMeshAgent>();
        if (randomism>0) {
            GetComponent<Renderer>().material.color = Color.green;
        } else {
            GetComponent<Renderer>().material.color = Color.red;
        }
        jumped = true;
        GetComponent<NavMeshAgent>().enabled = false;
        head = transform.GetChild(0).gameObject;
        ball = GameObject.Find("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        kicker = GameObject.Find("KickingPlayer1");
        kickerPosition = kicker.GetComponent<Transform>();
        timer += Time.deltaTime;
        if (timer>0.5f&&jumped==false) {
            jumped = true;
            timer = 0;
            rb.AddForce(0,Random.Range(100f,200f),0);
        }
        if (JEK_Game.level>5&&jumped==false) {
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Random.Range(-100f,100f),Random.Range(200f,1000f),Random.Range(-100f,100f));
            jumped = true;
            GetComponent<NavMeshAgent>().enabled = true;
            theNav.destination = ball.transform.position;
            GetComponent<NavMeshAgent>().speed = Random.Range(3f,7f);
        }
    }
    void OnCollisionEnter(Collision col) {
        if (col.collider.CompareTag("Player")) {
            rb.freezeRotation = false;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Random.Range(-3000f,3000f), Random.Range(-3000f, 3000f), Random.Range(-3000f, 3000f));
            transform.DetachChildren();
            if (!head.GetComponent<Rigidbody>())
            {
                headBody = head.AddComponent<Rigidbody>();
                headBody.isKinematic = false;
                headBody.AddForce(Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f));
            }
        }
        if (col.collider.CompareTag("Ladder")) {
            jumped = false;
        }
    }
}
