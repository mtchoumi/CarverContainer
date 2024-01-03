using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSH_Move : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 400f, ~LayerMask.GetMask("Player"));
            float distance = Mathf.Abs(hit.point.x - transform.position.x);
            if (hit.collider != null)
            {
                print(hit.collider.name);
            }
            if(distance > transform.localScale.x || hit.collider.name == "JSH_Point(Clone)")
            {
                transform.position = new Vector3(transform.position.x + transform.localScale.x, transform.position.y, transform.position.z);
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, 400f, ~LayerMask.GetMask("Player"));
            float distance = Mathf.Abs(hit.point.x - transform.position.x);
            if (hit.collider != null)
            {
                print(hit.collider.name);
            }
            if(distance > transform.localScale.x || hit.collider.name == "JSH_Point(Clone)")
            {
                transform.position = new Vector3(transform.position.x - transform.localScale.x, transform.position.y, transform.position.z);
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 400f, ~LayerMask.GetMask("Player"));
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if (hit.collider != null)
            {
                print(hit.collider.name);
            }
            if(distance > transform.localScale.y || hit.collider.name == "JSH_Point(Clone)")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 400f, ~LayerMask.GetMask("Player"));
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if (hit.collider != null)
            {
                print(hit.collider.name);
            }
            if(distance > transform.localScale.y || hit.collider.name == "JSH_Point(Clone)")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y, transform.position.z);
            }
        }
    }
}
