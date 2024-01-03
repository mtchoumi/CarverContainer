using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MH_cameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocity;

[SerializeField] private float smoothTimeY;
[SerializeField]public float smoothTimeX;

public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x,smoothTimeX);
		float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y,smoothTimeY);
		
		transform.position = new Vector3(posX,posY,transform.position.z);
		
    }


}
