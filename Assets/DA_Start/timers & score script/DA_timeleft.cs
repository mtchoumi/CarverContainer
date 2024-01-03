using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DA_timeleft : MonoBehaviour
{
   
    float currentTime = 0f;
   public static float startingTime = 33f;
    // Start is called before the first frame update
    [SerializeField] Text countdownText;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
      currentTime -= 1 * Time.deltaTime;
      countdownText.text = currentTime.ToString ("0");
    
        if (currentTime > 29)
        {
          countdownText.text =  "30";    
        }

      if (currentTime < 1)
      {


           if (currentTime < 0)
      {
          SceneManager.LoadScene("DA_EndScene");
      }
    }
}
}