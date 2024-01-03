using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DA_CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 3f;
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
    
      if (currentTime < 1)
      {
          countdownText.text = "GO!";

           if (currentTime < 0)
      {
          Destroy (gameObject);
      }
    }
}
}
