using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WCK_LaserMove : MonoBehaviour
{
	bool original;
	float DEG_TO_RAD = 0.0174532925199f;
	[SerializeField] bool homing;
	[SerializeField] float speed;
	WCK_Move player;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name[gameObject.name.Length-1] == 'o') {
			/* o for original - clones will have ) */
			original = true;
		} else {
			original = false;
		}
		if(!original) {
			player = Component.FindObjectOfType<WCK_Move>();
		}
    }

	void OnEnable() {
		if(homing) {
			if(!player) {
				player = Component.FindObjectOfType<WCK_Move>();
			}
			transform.right = (player.Position - transform.position);
		}
	}
    // Update is called once per frame
    void Update()
    {
		int destroyX;
		int destroyY;

		if(Mathf.Sin((transform.eulerAngles.z)*DEG_TO_RAD) > 0) {
			destroyY = 1; 
		} else {
			destroyY = -1;
		}

		if(Mathf.Cos((transform.eulerAngles.z)*DEG_TO_RAD) > 0) {
			destroyX = 1;
		} else {
			destroyX = -1;
		}

		if(!original) {
			transform.position += transform.right * Time.deltaTime * speed;
			
			if(transform.position.x*(float)destroyX > 6.66f) {
				gameObject.SetActive(false);
			}
			if(transform.position.y*(float)destroyY > 5.0f) {
				gameObject.SetActive(false);
			}
		}
    }
	
	void OnTriggerEnter2D(Collider2D other) {
		if(!other.gameObject) {
			return;
		}
		if(player) {
			if(other.gameObject.CompareTag("Player")) {
				player.Score--;
			}
		}
	}
}
