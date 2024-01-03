using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class JEK_Game : MonoBehaviour
{
    float height;
    float curve;
    Vector3 mousePos, point;
    Rigidbody rb;
    public GameObject aimArrow;
    Camera mainCam;
    Vector3 freeKickPosition, goalkeeperPosition, wallPosition;
    public static bool shot;
    float timer;
    public GameObject goalkeeper, wallGuide;
    public GameObject wall1, wall2, wall3, wall4;
    Vector3 wall1Start, wall2Start, wall3Start, wall4Start;
    public static int level;
    bool setup;
    float timer2;
    GameObject mouseClick, mouseNotClick, leftArrowKey, rightArrowKey;
    Vector3 clickStart, notClickstart, leftStart, rightStart;
    Vector3 change;
    bool[] curveStuff = new bool[] { false, false, false, false };
    GameObject indicator1, indicator2, indicator3, indicator4;
    Vector3[] positions = new Vector3[] { new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0) };
    public GameObject indication;
    int score;
    int[] scores = new int[] { 0, 0, 0, 0, 0 };
    GameObject scoreBox;
    public GameObject winning;
    public GameObject fan;
    public GameObject                    sign1,        sign2,        sign3,         sign4;
    Vector3[] signStart = new Vector3[] {new Vector3(),new Vector3(),new Vector3(), new Vector3() };
    int randomPosition;
    float timer3;
    bool reachedTop;
    FileStream stream;
    List<string> highscores = new List<string>();
    public GameObject sliderismism, sliderisms, highscoreBoard;
    Vector3 highscoreStart;
    public GameObject kicker;
    bool kicking;
    bool alreadyKicked;
    Vector3 kickerStart;
    Vector3 goalkeeperStart;
    Vector3 directionism;
    public Sprite goalkeepIdle, goalkeepDive;
    AudioSource audioSource;
    public AudioClip intro1, intro2, intro3;
    public AudioClip shoot1, shoot2, shoot3;
    public AudioClip wallHit1, wallHit2, wallHit3, wallHit4;
    public AudioClip post1, post2, post3;
    public AudioClip crossbar1, crossbar2, crossbar3;
    public AudioClip crowd1, crowd2, crowd3;
    public AudioClip closeMiss1, closeMiss2, closeMiss3;
    public AudioClip save1, save2, save3;
    public AudioClip farMiss1, farMiss2, farMiss3;
    public AudioClip goal1, goal2, goal3;
    public AudioClip topCorner, bottomCorner, topArea;
    public AudioClip win1, lose1;
    List<AudioClip> audioQ = new List<AudioClip>();
    bool playingAudio;
    int whichAudio;
    float audioLength;
    float audioTimer;
    int attempts;
    public GameObject attemptText;
    int misses;
    int crossbarHits;
    bool sixed;
    //static FileStream achFile = new FileStream("Assets/JEK_Game/JEK_Achievements.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
    static FileStream highFile = new FileStream("Assets/JEK_Title/JEK_Highscores.txt", FileMode.OpenOrCreate);
    //StreamWriter achWriter = new StreamWriter(achFile);
    //StreamReader achReader = new StreamReader(achFile);
    //StreamReader steve = new StreamReader("/Users/jacksonkrausche/Downloads/Template/Assets/JEK_Game/JEK_Achievements.txt");
    //StreamReader jobs = new StreamReader(highFile);
    List<string> achievers2 = new List<string>();
    public static List<string> achievers = new List<string>() { "No one", "No one", "No one", "No one", "No one" };
    //List<StreamReader> readersOfTheStream = new List<StreamReader>();
    //List<StreamWriter> writersOfTheStream = new List<StreamWriter>();
    bool reset;
    //public Terrain theTerrain;
    //public GameObject descText;
    //public InputField nameField;
    string namer;
    int highValIndex;
    int lowScoreIndex;
    //public GameObject claimer1, claimer2, claimer3, claimer4, claimer5, claimer6, claimer7;
    //public GameObject achievementText;
    //public GameObject instructions;
    // Start is called before the first frame update
    void Start()
    {
        shot = false;
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
        curve = 0;
        height = 0;
        timer = 0;
        level = 1;
        score = 0;
        namer = "";
        //theTerrain.treeDistance = 1000000f;
        //theTerrain.treeMaximumFullLODCount = 100000;
        freeKickPosition = transform.position;
        goalkeeperPosition = goalkeeper.transform.position;
        wallPosition = wallGuide.transform.position;
        wallGuide.transform.position += new Vector3(0, -5f, 0);
        rb.isKinematic = true;
        wall1Start = wall1.transform.position;
        wall1.transform.position -= new Vector3(0, 0, 40f);
        wall2Start = wall2.transform.position;
        wall2.transform.position -= new Vector3(0, 0, 40f);
        wall3Start = wall3.transform.position;
        wall3.transform.position -= new Vector3(0, 0, 40f);
        wall4Start = wall4.transform.position;
        wall4.transform.position -= new Vector3(0, 0, 40f);
        mouseClick = GameObject.Find("MouseClick01");
        clickStart = mouseClick.transform.position;
        mouseNotClick = GameObject.Find("MouseNotClick01");
        notClickstart = mouseNotClick.transform.position;
        leftArrowKey = GameObject.Find("LeftArrowKey01");
        leftStart = leftArrowKey.transform.position;
        rightArrowKey = GameObject.Find("RightArrowKey01");
        rightStart = rightArrowKey.transform.position;
        change = new Vector3(0.1f, 0, 0);
        positions[0] = transform.position + new Vector3(-2f, 0, 0);
        positions[1] = transform.position + new Vector3(-1f, 0, 0);
        positions[2] = transform.position + new Vector3(1f, 0, 0);
        positions[3] = transform.position + new Vector3(2f, 0, 0);
        indicator1 = Instantiate(indication, positions[0], Quaternion.identity);
        indicator1.transform.rotation = Quaternion.Euler(0, 0, 90f);
        indicator2 = Instantiate(indication, positions[1], Quaternion.identity);
        indicator2.transform.rotation = Quaternion.Euler(0, 0, 90f);
        indicator3 = Instantiate(indication, positions[2], Quaternion.identity);
        indicator3.transform.rotation = Quaternion.Euler(0, 0, -90f);
        indicator4 = Instantiate(indication, positions[3], Quaternion.identity);
        indicator4.transform.rotation = Quaternion.Euler(0, 0, -90f);
        scoreBox = GameObject.Find("TotalScore");
        scoreBox.transform.position -= new Vector3(0, 0, 1000f);
        float zPosition = Random.Range(55f, 75f);
        for (int i = 0; i < 100; i++)
        {
            Instantiate(fan, new Vector3(Random.Range(-55f, 50f), zPosition - 50f, zPosition), Quaternion.identity);
            zPosition = Random.Range(55f, 75f);
        }
        float xPosition = Random.Range(40f, 60f);
        for (int i = 0; i < 50; i++)
        {
            Instantiate(fan, new Vector3(xPosition, xPosition - 36f, Random.Range(0f, 65f)), Quaternion.identity);
            xPosition = Random.Range(40, 60f);
        }
        xPosition = Random.Range(-70f, -50f);
        for (int i = 0; i < 50; i++)
        {
            Instantiate(fan, new Vector3(xPosition, (xPosition + 45f) * -1f, Random.Range(0f, 65f)), Quaternion.identity);
            xPosition = Random.Range(-70, -50f);
        }
        randomPosition = 0;
        sign1 = GameObject.Find("GoalSign#1,01");
        sign2 = GameObject.Find("GoalSign#2,01");
        sign3 = GameObject.Find("GoalSign#3,01");
        sign4 = GameObject.Find("GoalSign#4,01");
        signStart[0] = sign1.transform.position;
        signStart[1] = sign2.transform.position;
        signStart[2] = sign3.transform.position;
        signStart[3] = sign4.transform.position;
        sign1.GetComponent<SpriteRenderer>().enabled = false;
        sign2.GetComponent<SpriteRenderer>().enabled = false;
        sign3.GetComponent<SpriteRenderer>().enabled = false;
        sign4.GetComponent<SpriteRenderer>().enabled = false;
        reachedTop = false;
        StreamReader reader = new StreamReader(highFile);
        while (reader.Peek()>=0) {
            highscores.Add(reader.ReadLine());
        }
        int highVal = 0;
        highValIndex = 0;
        int bruh = highscores.Count;
        for (int i=0; i<bruh; i++) {
            int theHighscoreThing;
            string tennis = highscores[i].Substring(0, 3);
            int.TryParse(tennis, out theHighscoreThing);
            if (theHighscoreThing>highVal) {
                highVal = theHighscoreThing;
                highValIndex = i;
            }
        }
        lowScoreIndex = 0;
        for (int i = 0; i < bruh; i++)
        {
            int theHighscoreThing;
            string tennis = highscores[i].Substring(0, 3);
            int.TryParse(tennis, out theHighscoreThing);
            if (theHighscoreThing < highVal)
            {
                highVal = theHighscoreThing;
                lowScoreIndex = i;
            }
        }
        sliderismism = GameObject.Find("Slider");
        sliderisms = GameObject.Find("Slider2");
        highscoreBoard = GameObject.Find("HighscoreText");
        highscoreBoard.GetComponent<Text>().text = "Highscore: " + highscores[highValIndex];
        highscoreStart = highscoreBoard.transform.position;
        kicking = false;
        alreadyKicked = false;
        kickerStart = kicker.transform.position;
        goalkeeperStart = goalkeeper.transform.position;
        playingAudio = false;
        whichAudio = Random.Range(1, 3);
        if (whichAudio==1)
        {
            audioQ.Add(intro1);
        } else if (whichAudio==2)
        {
            audioQ.Add(intro2);
        } else
        {
            audioQ.Add(intro3);
        }
        audioLength = 0;
        audioTimer = 0;
        audioSource = GetComponent<AudioSource>();
        attempts = 10;
        misses = 0;
        sixed = false;
        //achWriter.AutoFlush = true;
        for (int i=0; i<8; i++)
        {
            //print(achReader.Peek());
        }
        /*
        while (achReader.Peek() >= 0)
        {
            achievers2.Add(achReader.ReadLine());
            //print(achReader.ReadLine());
        }
        */
        //achievementText.SetActive(false);
        for (int i = 0; i < achievers2.Count - 1; i++)
        {
            print("d" + achievers2[i]);
        }/*
        readersOfTheStream.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve1.txt"));
        readersOfTheStream.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve2.txt"));
        readersOfTheStream.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve3.txt"));
        readersOfTheStream.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve4.txt"));
        readersOfTheStream.Add(new StreamReader("Assets/JEK_Game/JEK_Achieve5.txt"));
        for (int i = 0; i < readersOfTheStream.Count; i++)
        {
            achievers2.Add(readersOfTheStream[i].ReadLine());
            print("reed" + achievers2[i]);
            readersOfTheStream[i].Close();
        }
        print("e" + Application.dataPath);
        writersOfTheStream.Add(new StreamWriter("Assets/JEK_Game/JEK_Achieve1.txt"));
        writersOfTheStream.Add(new StreamWriter("Assets/JEK_Game/JEK_Achieve2.txt"));
        writersOfTheStream.Add(new StreamWriter("Assets/JEK_Game/JEK_Achieve3.txt"));
        writersOfTheStream.Add(new StreamWriter("Assets/JEK_Game/JEK_Achieve4.txt"));
        writersOfTheStream.Add(new StreamWriter("Assets/JEK_Game/JEK_Achieve5.txt"));
        for (int i=0; i<achievers2.Count; i++)
        {
            print(achievers2[i]);
        }
        */
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (level<6)
        {
            attemptText.GetComponent<Text>().text = "Attempts Left: " + attempts;
        } else
        {
            attemptText.GetComponent<Text>().text = "";
        }
        if (playingAudio == false && audioQ.Count>0)
        {
            //audioSource.PlayOneShot(audioQ[0]);
            playingAudio = true;
            audioLength = audioQ[0].length;
            audioQ.RemoveAt(0);
        }
        if (audioTimer > audioLength + 0.5f)
        {
            playingAudio = false;
        }
        timer3 += Time.deltaTime;
        if (timer3 < 10f) {
            if (randomPosition == 1) {
                sign1.GetComponent<SpriteRenderer>().enabled = true;
                sign1.transform.position += new Vector3(0.5f, 0, 0);
            } else {
                sign1.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (randomPosition == 2) {
                sign2.GetComponent<SpriteRenderer>().enabled = true;
                sign2.transform.position += new Vector3(0.5f, 0, 0);
            } else{
                sign2.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (randomPosition == 3) {
                sign3.GetComponent<SpriteRenderer>().enabled = true;
                sign3.transform.position += new Vector3(0.5f, 0, 0);
            } else {
                sign3.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (randomPosition == 4) {
                sign4.GetComponent<SpriteRenderer>().enabled = true;
                sign4.transform.position += new Vector3(0.5f, 0, 0);
            } else {
                sign4.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        /*
        claimer1.GetComponent<Text>().text = "Claimed by: " + achievers[0];
        claimer2.GetComponent<Text>().text = "Claimed by: " + achievers[1];
        claimer3.GetComponent<Text>().text = "Claimed by: " + achievers[2];
        claimer4.GetComponent<Text>().text = "Claimed by: " + achievers[3];
        claimer5.GetComponent<Text>().text = "Claimed by: " + achievers[4];
        claimer6.GetComponent<Text>().text = "Claimed by: " + highscores[highValIndex];
        claimer7.GetComponent<Text>().text = "Claimed by: " + highscores[lowScoreIndex];
        */
        /*
        if ((level > 1 && level < 6) ||level==0) {
            highscoreBoard.SetActive(false);
        } else
        {
            highscoreBoard.SetActive(true);
        }
        if (level>5)
        {
            instructions.SetActive(true);
        } else
        {
            instructions.SetActive(false);
        }
        */
        mousePos = Input.mousePosition;
        point = mainCam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCam.nearClipPlane));
        if (level<3||level>4) {
            aimArrow.transform.rotation = Quaternion.Euler(90 - (height * 3), (point.x + 5f) * 180f, 0);
        }
        if (level==3) {
            aimArrow.transform.rotation = Quaternion.Euler(90 - (height * 3), (point.x + 20f) * 180f, 0);
        }
        if (level==4) {
            aimArrow.transform.rotation = Quaternion.Euler(90 - (height * 3), (point.x - 8f) * 180f, 0);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space)&&level==0)
        {
            if (nameField.text.Length > 3)
            {
                namer = nameField.text.Substring(0, 3);
            }
            else
            {
                namer = nameField.text;
            }
            level = 1;
            shot = false;
            //SceneManager.LoadScene("JEK_TheGame", LoadSceneMode.Single);
        }
        */
        /*
        if (Input.GetKeyDown(KeyCode.Space)&&level>5)
        {
            SceneManager.LoadScene("JEK_TheGame");
        }
        if (Input.GetKeyDown(KeyCode.H)&&level>5)
        {
            achievementText.SetActive(true);
            scoreBox.transform.position -= new Vector3(0, 0, 1000f);
        }
        if (Input.GetKeyDown(KeyCode.Return)&&level>5)
        {
            SceneManager.LoadScene("Loading");
        }
        */
        timer2 += Time.deltaTime;
        /*
        if (level==0)
        {
            mouseClick.SetActive(false);
            mouseNotClick.SetActive(false);
            leftArrowKey.SetActive(false);
            rightArrowKey.SetActive(false);
            attemptText.SetActive(false);
        } else
        {
            mouseClick.SetActive(true);
            mouseNotClick.SetActive(true);
            leftArrowKey.SetActive(true);
            rightArrowKey.SetActive(true);
            attemptText.SetActive(true);
            descText.SetActive(false);
        }
        */
        if (level==1) {
            //leftArrowKey.transform.position -= new Vector3(0,0,40f);
            //rightArrowKey.transform.position -= new Vector3(0,0,40f);
            if (timer2%1f<0.5f&&timer2<5f) {
                mouseClick.transform.position = clickStart;
                mouseNotClick.transform.position -= new Vector3(0,0,40f);
            }
            if (timer2%1f>0.5f&&timer2<5f) {
                mouseClick.transform.position -= new Vector3(0,0,40f);
                mouseNotClick.transform.position = notClickstart;
            }
            if (timer2>5) {
                mouseClick.transform.position -= new Vector3(0,0,40f);
                mouseNotClick.transform.position -= new Vector3(0,0,40f);
            }
            if (timer2 % 1f < 0.5f && timer2 < 5f)
            {
                leftArrowKey.transform.position = leftStart;
                rightArrowKey.transform.position -= new Vector3(0, 0, 40f);
            }
            if (timer2 % 1f > 0.5f && timer2 < 5f)
            {
                rightArrowKey.transform.position = rightStart;
                leftArrowKey.transform.position -= new Vector3(0, 0, 40f);
            }
            if (timer2 > 5)
            {
                leftArrowKey.transform.position -= new Vector3(0, 0, 40f);
                rightArrowKey.transform.position -= new Vector3(0, 0, 40f);
            }
        }
        print(level);
        if (level==1)
        {
            mouseClick.SetActive(true);
            mouseNotClick.SetActive(true);
            leftArrowKey.SetActive(true);
            rightArrowKey.SetActive(true);
        }
        if (level>1) {
            mouseClick.SetActive(false);
            mouseNotClick.SetActive(false);
            leftArrowKey.SetActive(false);
            rightArrowKey.SetActive(false);
        }
        if (level==5&&shot!=true&&kicking==false) {
            if (transform.position.x>8||transform.position.x<-20) {
                change = new Vector3(-1f*change.x,change.y,change.z);
            }
            transform.position += change;
            wall1.transform.position += change;
            wall2.transform.position += change;
            wall3.transform.position += change;
            wall4.transform.position += change;
            aimArrow.transform.position += change;
            positions[0] = transform.position + new Vector3(-2f,0,0);
            positions[1] = transform.position + new Vector3(-1f,0,0);
            positions[2] = transform.position + new Vector3(1f,0,0);
            positions[3] = transform.position + new Vector3(2f,0,0);
        }
        if (level == 6 && sixed == false) {
            sixed = true;
            level++;
            for (int i = 0; i < 80; i += 5)
            {
                Instantiate(winning, new Vector3(-40 + i, -5f, 25f), Quaternion.identity);
                Instantiate(winning, new Vector3(30, -5f, 25f - i), Quaternion.identity);
                Instantiate(winning, new Vector3(-35f, -5f, 25f - i), Quaternion.identity);
            }
            if (score>300f)
            {
                audioQ.Add(win1);
            } else
            {
                audioQ.Add(lose1);
            }
            GameObject texter;
            texter = GameObject.Find("Goals");
            texter.GetComponent<Text>().text = "Goals: " + scores[0] + " * 30";
            texter = GameObject.Find("TopCorners");
            texter.GetComponent<Text>().text = "Top Corners Hit: " + scores[1] + " * 90";
            texter = GameObject.Find("TopAreas");
            texter.GetComponent<Text>().text = "Top Areas Hit: " + scores[2] + " * 70";
            texter = GameObject.Find("BottomCorners");
            texter.GetComponent<Text>().text = "Bottom Corners Hit: " + scores[3] + " * 40";
            texter = GameObject.Find("FansHit");
            texter.GetComponent<Text>().text = "Fans hit: " + scores[4] + " * -10";
            scoreBox.transform.position += new Vector3(0, 0, 1000f);
            scoreBox.GetComponent<Text>().text = "Total Score: " + score;
            StreamWriter writer = new StreamWriter(highFile);
            if (misses == 0)
            {
                achievers[1] = "You!";
            }
            if (scores[4] > 9)
            {
                achievers[2] = "You!";
            }
            if (crossbarHits > 4)
            {
                achievers[3] = "You!";
            }
            if (scores[0] > 3)
            {
                achievers[0] = "You!";
            }
            writer.WriteLine(score + " " + namer);
            writer.Close();
            /*
            for (int i=0; i<=writersOfTheStream.Count-1; i++)
            {
                using (writersOfTheStream[i])
                {
                    writersOfTheStream[i].WriteLine(achievers2[i]);
                    writersOfTheStream[i].Close();
                }
            }
            */
            //achWriter.Close();
        }
        if (level==6)
        {
            GameObject texter;
            texter = GameObject.Find("Goals");
            texter.GetComponent<Text>().text = "Goals: " + scores[0] + " * 30";
            texter = GameObject.Find("TopCorners");
            texter.GetComponent<Text>().text = "Top Corners Hit: " + scores[1] + " * 90";
            texter = GameObject.Find("TopAreas");
            texter.GetComponent<Text>().text = "Top Areas Hit: " + scores[2] + " * 70";
            texter = GameObject.Find("BottomCorners");
            texter.GetComponent<Text>().text = "Bottom Corners Hit: " + scores[3] + " * 40";
            texter = GameObject.Find("FansHit");
            texter.GetComponent<Text>().text = "Fans hit: " + scores[4] + " * -10";
            scoreBox.transform.position += new Vector3(0, 0, 1000f);
            scoreBox.GetComponent<Text>().text = "Total Score: " + score;
        }
        if (Input.GetMouseButton(0)&&shot==false&&level>0) {
            print("aaaa");
            if (height<15f&&reachedTop==false) {
                height += 0.2f;
            }
            if (height>14.7f) {
                reachedTop = true;
            }
            if (reachedTop==true) {
                height -= 0.2f;
            }
            if (height<0f) {
                reachedTop = false;
            }
        }
        if (Input.GetMouseButtonUp(0)&&shot==false&&kicking==false&&level>0) {
            kicking = true;
        }
        if (attempts==0) {
            level = 6;
            attempts = 10101010;
            attemptText.SetActive(false);
        } else if (level!=0)
        {
            attemptText.SetActive(true);
        }
        if ((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A))&&curve>-0.2f && level > 0) {
            curve -= 0.01f;
        }
        if ((Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))&&curve<0.2f && level > 0) {
            curve += 0.01f;
        }
        if (curve<-0.1f) {
            curveStuff[0] = true;
        } else {
            curveStuff[0] = false;
        }
        if (curve<0) {
            curveStuff[2] = false;
            curveStuff[3] = false;
        }
        if (curve<-0.02f) {
            curveStuff[1] = true;
        } else {
            curveStuff[1] = false;
        }
        if (curve>0) {
            curveStuff[2] = true;
            curveStuff[0] = false;
            curveStuff[1] = false;
        }
        if (curve>0.02f) {
            curveStuff[2] = true;
        } else {
            curveStuff[2] = false;
        }
        if (curve>0.1f) {
            curveStuff[3] = true;
        } else {
            curveStuff[3] = false;
        }
        sliderismism.GetComponent<Slider>().value = curve;
        sliderisms.GetComponent<Slider>().value = height;
        if (curveStuff[0]==true) {
            indicator1.transform.position = positions[0];
        } else {
            indicator1.transform.position += new Vector3(0,0,-40f);
        }
        if (curveStuff[1]==true) {
            indicator2.transform.position = positions[1];
        } else {
            indicator2.transform.position += new Vector3(0,0,-40f);
        }
        if (curveStuff[2]==true) {
            indicator3.transform.position = positions[2];
        } else {
            indicator3.transform.position += new Vector3(0,0,-40f);
        }
        if (curveStuff[3]==true) {
            indicator4.transform.position = positions[3];
        } else {
            indicator4.transform.position += new Vector3(0,0,-40f);
        }
        if (Input.GetKeyDown("r")&&shot==true) {
            misses++;
            attempts--;
            alreadyKicked = false;
            rb.isKinematic = true;
            height = 0;
            transform.position = freeKickPosition;
            aimArrow.transform.position = transform.position + new Vector3(0,0,1f);
            goalkeeper.transform.position = goalkeeperPosition;
            if (level==5) {
                wall1.transform.position = wall1Start;
                wall2.transform.position = wall2Start;
                wall3.transform.position = wall3Start;
                wall4.transform.position = wall4Start;
                positions[0] = transform.position + new Vector3(-2f,0,0);
                positions[1] = transform.position + new Vector3(-1f,0,0);
                positions[2] = transform.position + new Vector3(1f,0,0);
                positions[3] = transform.position + new Vector3(2f,0,0);
            }
            timer = 0;
            shot = false;
            reachedTop = false;
        }
        if (shot==true) {
            timer += Time.deltaTime;
            sliderismism.gameObject.SetActive(false);
            sliderisms.gameObject.SetActive(false);
            aimArrow.GetComponent<SpriteRenderer>().enabled = false;
            goalkeeper.GetComponent<SpriteRenderer>().sprite = goalkeepDive;
            if (goalkeeper.transform.position.x>transform.position.x) {
                goalkeeper.transform.position -= new Vector3(0.03f,0,0);
            } else if (goalkeeper.transform.position.x<transform.position.x) {
                goalkeeper.transform.position += new Vector3(0.03f,0,0);
            }
            if (goalkeeper.transform.position.x<-5f) {
                if ((directionism.x * 40 < -1f || directionism.x * 40 > 1f) && transform.position.z > 9.5f)
                {
                    if (height > 10f)
                    {
                        goalkeeper.transform.rotation = Quaternion.Euler(goalkeeper.transform.rotation.x, goalkeeper.transform.rotation.y, 15f);
                        goalkeeper.transform.position = new Vector3(goalkeeper.transform.position.x, 2.5f, goalkeeper.transform.position.z);
                    }
                    else if (height > 7f)
                    {
                        goalkeeper.transform.rotation = Quaternion.Euler(goalkeeper.transform.rotation.x, goalkeeper.transform.rotation.y, 30f);
                        goalkeeper.transform.position = new Vector3(goalkeeper.transform.position.x, 2.5f, goalkeeper.transform.position.z);
                    }
                    else
                    {
                        goalkeeper.transform.rotation = Quaternion.Euler(goalkeeper.transform.rotation.x, goalkeeper.transform.rotation.y, 90f);
                        goalkeeper.transform.position = new Vector3(goalkeeper.transform.position.x, 1.3f, goalkeeper.transform.position.z);
                    }
                }
            }
            if (goalkeeper.transform.position.x > -5f)
            {
                if ((directionism.x * 40 < -1f || directionism.x * 40 > 1f) && transform.position.z > 9.5f)
                {
                    if (height > 10f)
                    {
                        goalkeeper.transform.rotation = Quaternion.Euler(goalkeeper.transform.rotation.x, goalkeeper.transform.rotation.y, -15f);
                        goalkeeper.transform.position = new Vector3(goalkeeper.transform.position.x, 2.5f, goalkeeper.transform.position.z);
                    }
                    else if (height > 7f)
                    {
                        goalkeeper.transform.rotation = Quaternion.Euler(goalkeeper.transform.rotation.x, goalkeeper.transform.rotation.y, -30f);
                        goalkeeper.transform.position = new Vector3(goalkeeper.transform.position.x, 2.5f, goalkeeper.transform.position.z);
                    }
                    else
                    {
                        goalkeeper.transform.rotation = Quaternion.Euler(goalkeeper.transform.rotation.x, goalkeeper.transform.rotation.y, -90f);
                        goalkeeper.transform.position = new Vector3(goalkeeper.transform.position.x, 1.3f, goalkeeper.transform.position.z);
                    }
                }
            }
            if (timer<0.5f) {
                wall1.GetComponent<Rigidbody>().velocity = new Vector3(0,1f,0);
                wall2.GetComponent<Rigidbody>().velocity = new Vector3(0,1f,0);
                wall3.GetComponent<Rigidbody>().velocity = new Vector3(0,1f,0);
                wall4.GetComponent<Rigidbody>().velocity = new Vector3(0,1f,0);
            }
            if (timer>0.1f&&timer<1f) {
                rb.velocity += new Vector3(curve,0,0);
            }
            if (timer>5f) {
                misses++;
                attempts--;
                alreadyKicked = false;
                rb.isKinematic = true;
                transform.position = freeKickPosition;
                aimArrow.transform.position = transform.position + new Vector3(0, 0, 1f);
                goalkeeper.transform.position = goalkeeperPosition;
                if (level == 5)
                {
                    wall1.transform.position = wall1Start;
                    wall2.transform.position = wall2Start;
                    wall3.transform.position = wall3Start;
                    wall4.transform.position = wall4Start;
                    positions[0] = transform.position + new Vector3(-2f, 0, 0);
                    positions[1] = transform.position + new Vector3(-1f, 0, 0);
                    positions[2] = transform.position + new Vector3(1f, 0, 0);
                    positions[3] = transform.position + new Vector3(2f, 0, 0);
                }
                timer = 0;
                shot = false;
                height = 0;
            }
            //transform.rotation.SetLookRotation(new Vector3(Random.Range(-10f,10f),Random.Range(-10f,10f),Random.Range(-10f,10f)));
        } else {
            goalkeeper.transform.position = goalkeeperPosition;
            goalkeeper.GetComponent<SpriteRenderer>().sprite = goalkeepIdle;
            goalkeeper.transform.rotation = Quaternion.Euler(0,0,0);
            wall1.GetComponent<Rigidbody>().velocity = new Vector3(0,-6f,0);
            wall2.GetComponent<Rigidbody>().velocity = new Vector3(0,-6f,0);
            wall3.GetComponent<Rigidbody>().velocity = new Vector3(0,-6f,0);
            wall4.GetComponent<Rigidbody>().velocity = new Vector3(0,-6f,0);
            sliderismism.gameObject.SetActive(true);
            sliderisms.gameObject.SetActive(true);
            aimArrow.GetComponent<SpriteRenderer>().enabled = true;
        }
        if (kicking == false && shot == false) {
            kicker.transform.position = transform.position + new Vector3(3f, 1.7f, -5f);
        }
        if (kicking == true) {
            Vector3 translationingismthing = transform.position - kicker.transform.position;
            kicker.transform.Translate(translationingismthing * 0.03f);
        }
    }
    void OnCollisionEnter(Collision col) {
        if (col.collider.CompareTag("Boss")) {
            whichAudio = Random.Range(1, 3);
            if (whichAudio == 1)
            {
                audioQ.Add(save1);
            }
            else if (whichAudio == 2)
            {
                audioQ.Add(save2);
            }
            else
            {
                audioQ.Add(save3);
            }
        }
        if (col.collider.CompareTag("Enemy")) {
            whichAudio = Random.Range(1, 4);
            if (whichAudio == 1)
            {
                audioQ.Add(wallHit1);
            }
            else if (whichAudio == 2)
            {
                audioQ.Add(wallHit2);
            }
            else if (whichAudio == 3)
            {
                audioQ.Add(wallHit3);
            } else
            {
                audioQ.Add(wallHit4);
            }
        }
        if (col.collider.CompareTag("Finish")) {
            if (col.gameObject.name == "TopPost") {
                crossbarHits++;
                whichAudio = Random.Range(1, 3);
                if (whichAudio == 1)
                {
                    audioQ.Add(crossbar1);
                }
                else if (whichAudio == 2)
                {
                    audioQ.Add(crossbar2);
                }
                else
                {
                    audioQ.Add(crossbar3);
                }
            } else
            {
                whichAudio = Random.Range(1, 3);
                if (whichAudio == 1)
                {
                    audioQ.Add(post1);
                }
                else if (whichAudio == 2)
                {
                    audioQ.Add(post2);
                }
                else
                {
                    audioQ.Add(post3);
                }
            }
        }
        if (col.collider.CompareTag("Pickup")) {
            score -= 10;
            scores[4]++;
            whichAudio = Random.Range(1, 3);
            if (whichAudio == 1)
            {
                audioQ.Add(crowd1);
            }
            else if (whichAudio == 2)
            {
                audioQ.Add(crowd2);
            }
            else
            {
                audioQ.Add(crowd3);
            }
        }
        if (col.collider.CompareTag("Respawn")&&alreadyKicked==false) {
            kicking = false;
            rb.isKinematic = false;
            if (level < 3 || level > 4) {
                point += new Vector3(5f, 0, 0);
            }
            if (level == 3) {
                point += new Vector3(20f, 0, 0);
            }
            if (level == 4) {
                point += new Vector3(-8f, 0, 0);
            }
            directionism = point;
            rb.AddForce(directionism.x * 40, height, 25f, ForceMode.Impulse);
            shot = true;
            rb.angularVelocity += new Vector3(0, 0, Random.Range(-50f, 50f));
            alreadyKicked = true;
            whichAudio = Random.Range(1, 3);
            if (whichAudio == 1)
            {
                audioQ.Add(shoot1);
            }
            else if (whichAudio == 2)
            {
                audioQ.Add(shoot2);
            }
            else
            {
                audioQ.Add(shoot3);
            }
        }
        if (col.collider.CompareTag("Goal")) {
            level++;
            attempts--;
            timer2 = 0;
            if (level==2) {
                freeKickPosition -= new Vector3(0,0,2f);
                wallGuide.transform.position = wallPosition;
                wall1.transform.position = wall1Start;
                wall2.transform.position = wall2Start;
                wall3.transform.position = wall3Start;
                wall4.transform.position = wall4Start;
            }
            if (level==3) {
                freeKickPosition -= new Vector3(15f,0,-2f);
                wall1.transform.position -= new Vector3(8f,0,0);
                wall2.transform.position -= new Vector3(8f,0,0);
                wall3.transform.position -= new Vector3(8f,0,0);
                wall4.transform.position -= new Vector3(8f,0,0);
            }
            if (level==4) {
                freeKickPosition += new Vector3(28f,0,0);
                wall1.transform.position += new Vector3(14f,0,0);
                wall2.transform.position += new Vector3(14f,0,0);
                wall3.transform.position += new Vector3(14f,0,0);
                wall4.transform.position += new Vector3(14f,0,0);
            }
            if (level==5) {
                freeKickPosition = new Vector3(-5f,freeKickPosition.y,freeKickPosition.z);
                wall1.transform.position -= new Vector3(8f,0,0);
                wall2.transform.position -= new Vector3(8f,0,0);
                wall3.transform.position -= new Vector3(8f,0,0);
                wall4.transform.position -= new Vector3(8f,0,0);
            }
            whichAudio = Random.Range(1, 3);
            if (whichAudio == 1)
            {
                audioQ.Add(goal1);
            }
            else if (whichAudio == 2)
            {
                audioQ.Add(goal2);
            }
            else
            {
                audioQ.Add(goal3);
            }
            if (col.gameObject.name == "TopLeftCorner" || col.gameObject.name == "TopRightCorner") {
                score += 90;
                scores[1]++;
                audioQ.Add(topCorner);
            }
            if (col.gameObject.name == "BottomLeftCorner" || col.gameObject.name == "BottomLeftCorner") {
                score += 40;
                scores[2]++;
                audioQ.Add(bottomCorner);
            }
            if (col.gameObject.name == "TopBar") {
                score += 70;
                scores[3]++;
                audioQ.Add(topArea);
            }
            kicker.transform.position = transform.position + new Vector3(3f, 1.7f, -5f);
            alreadyKicked = false;
            kicking = false;
            timer3 = 0;
            height = 0;
            randomPosition = Random.Range(1, 4);
            sign1.transform.position = signStart[0];
            sign2.transform.position = signStart[1];
            sign3.transform.position = signStart[2];
            sign4.transform.position = signStart[3];
            rb.isKinematic = true;
            transform.position = freeKickPosition;
            aimArrow.transform.position = transform.position + new Vector3(0,0,1f);
            goalkeeper.transform.position = goalkeeperPosition;
            timer = 0;
            score += 30;
            scores[0]++;
            shot = false;
            positions[0] = transform.position + new Vector3(-2f,0,0);
            positions[1] = transform.position + new Vector3(-1f,0,0);
            positions[2] = transform.position + new Vector3(1f,0,0);
            positions[3] = transform.position + new Vector3(2f,0,0);
        }
    }
}
