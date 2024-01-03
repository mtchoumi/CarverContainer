using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KHC_move : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;
    public Animator anim;
    // public KHC_characterController controller;

    private Vector2 prevelocity;
    private Vector2 offset = Vector2.zero;
    private Vector2 inertia = Vector2.zero;
    public float MovementSpeed = 30;
    public float JumpBoost = 6;
    public float JumpDuration = 1f;
    public float TractionPercentage = 10;

    public float deathDelay = 1f;
    private float timer = 0;
    private float gameTime = 0;
    private bool dying = false;
    private bool hitVoid = false;
    private float deathStart;
    
    
    public float snapDuration = 1f;
    private float snapTimer = 0;

    private bool Jump = false;
    private float preJAlt = 0;
    private float maxJAlt = 0;
    private float hori = 0;
    private float verti = 0;
    private float width = 0;
    private float height = 0;

    [HideInInspector] public const int maxJelly = 32;
    [HideInInspector] public GameObject jelMount;

    private bool onJelly = false;
    private bool onLedge = false;
    private bool onGrass = false;
    private bool onRiver = false;

    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private float riverMinX;
    private float riverMaxX;
    private float riverMinY;
    private float riverMaxY;

    private float buildingMaxX = -292f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        width = width * 3;
        height = height * 3;

        xMin = -750 + width / 2;
        xMax = 300 - width / 2;
        yMin = -300 + height / 2;
        yMax = 300 - height / 2;

        Rigidbody2D river = GameObject.Find("river").GetComponent<Rigidbody2D>();
        float midWidth = height / 2;
        float midHeight = height / 2;

        riverMinX = - river.transform.localScale.x / 2 + midWidth;
        riverMaxX = river.transform.localScale.x / 2 - midWidth;
        riverMinY = river.transform.position.y - river.transform.localScale.y / 2 + midHeight;
        riverMaxY = river.transform.position.y + river.transform.localScale.y / 2 - midHeight;

    }
    
    class getInput 
    { 
        public bool up = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8);
        public bool down = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad2); 
        public bool left = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4); 
        public bool right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6);
        public bool upleft = Input.GetKey(KeyCode.Keypad7);
        public bool upright = Input.GetKey(KeyCode.Keypad9);
        public bool downleft = Input.GetKey(KeyCode.Keypad1);
        public bool downright = Input.GetKey(KeyCode.Keypad7);
        public bool jump = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Keypad0);
    }

    void setMove (int i)
    {
        bool[] inputDirection = {new getInput().up, new getInput().down, new getInput().left, new getInput().right, new getInput().upleft, new getInput().upright, new getInput().downleft, new getInput().downright};
        float[] xShift = {0f, 0f, -1f, 1f, -0.7f, 0.7f, -0.7f, 0.7f};
        float[] yShift = {1f, -1f, 0f, 0f, 0.7f, 0.7f, -0.7f, -0.7f};
        if (inputDirection[i])
        {
            rb.velocity = new Vector2 (rb.velocity.x + xShift[i] * MovementSpeed, rb.velocity.y + yShift[i] * MovementSpeed); 
            if (onJelly)  { offset.x -= xShift[i] / 8; offset.y -= yShift[i] / 8; }
            if (i < 4) anim.SetInteger("UDLR", i);
        }
    }

    Rigidbody2D getRB (string id)
    {
        return GameObject.Find(id).GetComponent<Rigidbody2D>();
    }
    
    bool isSafe() 
    {
        return (onJelly || onLedge || onGrass || !onRiver);
    }

    void DeathAcquired(string cause)
    {
        print("death via " + cause);
        hitVoid = true;
        dying = true;
        deathStart = gameTime;
        col.enabled = false;
        rb.gravityScale = 32f;
        GameObject.Find("Main Camera").GetComponent<KHC_cameraFollow>().smoothFactor = 10f;
    }

    // int GetInputDirection()
    // {
    //     float x = Input.GetAxis("Horizontal");
    //     float y = Input.GetAxis("Vertical");
    // }

    void Update()
    {

        gameTime += Time.deltaTime;

        if (!dying)
        {

            if (!Jump)
            {
                //if vertical movement > horizontal movement && moving up
                // if (Mathf.Abs(Input.GetAxis("Vertical")) > Mathf.Abs(Input.GetAxis("Horizontal")) && Input.GetAxis("Vertical") > 0) anim.SetInteger("UDLR", 0);
                // if (Mathf.Abs(Input.GetAxis("Vertical")) > Mathf.Abs(Input.GetAxis("Horizontal")) && Input.GetAxis("Vertical") < 0) anim.SetInteger("UDLR", 1);
                // if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Abs(Input.GetAxis("Vertical")) && Input.GetAxis("Horizontal") < 0) anim.SetInteger("UDLR", 2);
                // if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Abs(Input.GetAxis("Vertical")) && Input.GetAxis("Horizontal") > 0) anim.SetInteger("UDLR", 3);

                // int dir = GetInputDirection())
                // if (dir >= 0) anim.SetInteger("UDLR", dir);

                if (new getInput().up || new getInput().down || new getInput().left || new getInput().right) 
                {
                    if (GameObject.Find("Canvas") != null) Destroy(GameObject.Find("Canvas"), 0f);
                    rb.velocity = Vector2.zero;
                    if (rb.transform.position.y < riverMinY && rb.transform.position.y > yMin && rb.transform.position.x > xMin && rb.transform.position.x < xMax || rb.transform.position.y < yMax && rb.transform.position.y > riverMinY && rb.transform.position.x > buildingMaxX && rb.transform.position.x < xMax)        
                    {
                        for (int i = 0; i < 8; i++) { setMove(i); }
                    }
                }

                else if (rb.velocity.x != inertia.x || rb.velocity.y != inertia.y)
                {
                    rb.velocity = prevelocity * ((100.0f - TractionPercentage) / 100.0f);
                    rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y);
                    if (Mathf.Abs(rb.velocity.x) < inertia.x + 1) rb.velocity = new Vector2 (inertia.x, rb.velocity.y);
                    if (Mathf.Abs(rb.velocity.y) < inertia.y + 1) rb.velocity = new Vector2 (rb.velocity.x, inertia.y);
                }

                prevelocity = rb.velocity;

            }

            timer += Time.deltaTime;

            if (new getInput().jump && !Jump)
            {
                Jump = true;
                col.enabled = false;
                timer = 0f;
                preJAlt = rb.position.y;
                maxJAlt = rb.position.y;
                hori = Input.GetAxis("Horizontal");
                verti = Input.GetAxis("Vertical");
                if (Mathf.Sign(verti) >= 0) rb.gravityScale = 18; else rb.gravityScale = 12;
                float directJump = ((JumpBoost / 4) + Mathf.Sign(verti) * (JumpBoost / 2));
                float adaptAltitude = Mathf.Abs((verti + Mathf.Sign(verti)) / (hori + Mathf.Sign(hori)) / 2);
                rb.velocity = new Vector2 (hori * MovementSpeed * (JumpBoost / 3), verti + MovementSpeed * directJump * adaptAltitude);
                anim.SetTrigger("jump");
            }

            if (Jump && timer < JumpDuration)
            {
                if (rb.position.y > maxJAlt) maxJAlt = rb.position.y;
                if (rb.position.x <= xMin || rb.position.x >= xMax) rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
                // if (rb.position.x > -545 && rb.position.x < -308 && rb.position.y > -133) rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
                // if (rb.position.x < -545) rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }

            if (Jump && timer >= JumpDuration && rb.position.y <= ((maxJAlt - preJAlt) * verti * 3 + preJAlt))
            {
                col.enabled = true;
                Jump = false;
                rb.gravityScale = 0;
                rb.velocity = new Vector2 (rb.velocity.x, 0);
                if (verti == 0) rb.transform.position = new Vector2 (rb.transform.position.x, preJAlt);
                if (rb.position.x <= xMin || rb.position.x >= xMax) rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }

            if (rb.transform.position.y > 200) QuickPlay.nextScene();

        }

        if (dying && transform.position.y < yMin * 3 && hitVoid)
        {
            hitVoid = false;
            transform.position = new Vector2 (0f, yMax * 3);
            getRB ("Main Camera").transform.position = new Vector2 (0f, yMax * 6);
        }

        if (dying && gameTime >= deathStart + deathDelay && rb.position.y <= -240)
        {
            dying = false;
            col.enabled = true;
            rb.gravityScale = 0f;
            transform.position = new Vector2 (0f, -240);
            GameObject.Find("Main Camera").GetComponent<KHC_cameraFollow>().smoothFactor = 5;
            //waterfalling / canyonfalling / blackhole / drowning
        }

        //animation

        anim.SetFloat("Speed", rb.velocity.magnitude);

    }

    // void FixedUpdate ()
    // {
    //     if (anim.GetInteger("UDLR") > 1) controller.Move(hori * MovementSpeed * Time.fixedDeltaTime, false, false);
    // }

    void OnTriggerEnter2D(Collider2D trig)
    {

        if ((trig.gameObject.tag == "jel" && jelMount == null) || (trig.gameObject.tag == "jel" && jelMount != null && trig.gameObject != jelMount && Vector2.Distance(this.gameObject.transform.position, trig.gameObject.transform.position) < Vector2.Distance(this.gameObject.transform.position, jelMount.transform.position))) 
        {
            jelMount = trig.gameObject;
            offset = getRB(jelMount.name).transform.position - rb.transform.position;
            inertia = getRB(jelMount.name).velocity - rb.velocity;
            onJelly = true;
        }

        if (trig.gameObject.name == "grass" || trig.gameObject.name == "ledge")
        {
            if (rb.position.y + height / 2 >= riverMinY && rb.position.y - height / 2 <= riverMaxY) {col.isTrigger = true;}
            else if (rb.position.y + height / 2 < riverMinY || rb.position.y - height / 2 > riverMaxY) {col.isTrigger = false;}
        }
        // if (trig.gameObject.name == "building") rb.velocity = new Vector2(rb.velocity.x * -2, rb.velocity.y * -2);

        if (trig.gameObject.name == "ledge" && rb.position.y - height / 2 > riverMaxY) onLedge = true;
        if (trig.gameObject.name == "grass" && rb.position.y + height / 2 < riverMinY) onGrass = true;
        if (trig.gameObject.name == "river") onRiver = true;

    }

    void OnTriggerExit2D(Collider2D trig)
    {
        
        if (trig.gameObject == jelMount)
        {

            if (snapTimer > snapDuration)
            {
                //snap animation play
                jelMount.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                jelMount.GetComponent<Rigidbody2D>().gravityScale = 32;
                jelMount.GetComponent<Collider2D>().enabled = false;
                Destroy (jelMount, deathDelay);
                snapTimer = 0f;
            }

            onJelly = false;
            jelMount = null;
            rb.velocity = Vector2.zero;
            inertia = Vector2.zero;        

        }

        if (trig.gameObject.name == "ledge" && rb.position.y - height / 2 < riverMaxY) onLedge = false;
        if (trig.gameObject.name == "grass" && rb.position.y + height / 2 > riverMinY) onGrass = false;
        if (trig.gameObject.name == "river") onRiver = false;

    }

    void OnTriggerStay2D(Collider2D trig)
    {
        
        if (trig.gameObject.name == "playerBoundsX") rb.velocity = new Vector2 (0f, rb.velocity.y);
        if (trig.gameObject.name == "playerBoundsY") rb.velocity = new Vector2 (rb.velocity.x, 0f);

        if (!Jump && trig.gameObject == jelMount) 
        {

            Vector2 rbJM = getRB(jelMount.name).transform.position;
            float newX = rbJM.x - offset.x;
            float newY = rbJM.y - offset.y;
            
            if (transform.position.x <= buildingMaxX + width / 2) newX = buildingMaxX + width / 2;
            rb.transform.position = new Vector2 (newX, newY);

            offset = getRB(jelMount.name).transform.position - rb.transform.position;
            inertia = getRB(jelMount.name).velocity - rb.velocity;

            snapTimer += Time.deltaTime;

        }

        if (!Jump && trig.gameObject.name == "river" && !isSafe()) DeathAcquired("drowning");

    }

}