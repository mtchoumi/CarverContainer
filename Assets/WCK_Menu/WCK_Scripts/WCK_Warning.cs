using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCK_Warning : MonoBehaviour
{
	float timer = 0.0f;
	bool original;
	[SerializeField] float alive;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "warning") {
			original = true;
		} else {
			original = false;
		}
    }

    // Update is called once per frame
    void Update()
    {
		if(!original) {
			timer += Time.deltaTime;
			if(timer > alive) {
				timer = 0.0f;
				gameObject.SetActive(false);
			}
		}
    }
}
