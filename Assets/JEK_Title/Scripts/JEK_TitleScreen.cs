using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JEK_TitleScreen : MonoBehaviour
{
    public InputField nameField;
    public static string namer;
    public GameObject ballToShoot;
    public GameObject timerText;
    float timer;
    Vector3 startPosition;
    bool started;
    // Start is called before the first frame update
    void Start()
    {
        namer = "";
        startPosition = ballToShoot.transform.position;
        timer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 2f)
        {

        }
        if (timer > 2f && started == false)
        {
            ballToShoot.transform.position = startPosition;
            started = true;
        }
        if (timer > 2f && timer < 5f)
        {
            ballToShoot.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (timer > 5f)
        {
            ballToShoot.GetComponent<Rigidbody>().AddForce(Random.Range(100f, 1000f), Random.Range(0f, 500f), 0);
            timer = 0;
            started = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (nameField.text.Length > 3)
        {
            namer = nameField.text.Substring(0, 3);
        }
        else
        {
            namer = nameField.text;
        }
        JEK_Game.level = 1;
        JEK_Game.shot = false;
        SceneManager.LoadScene("JEK_TheGame");
    }
}
