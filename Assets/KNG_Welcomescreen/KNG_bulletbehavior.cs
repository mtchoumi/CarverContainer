using UnityEngine;

public class KNG_bulletbehavior : MonoBehaviour
{
 // Update is called once per frame
    public float speed = 4.5f;
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Rwall")
        {
            Destroy(gameObject);
        }
        
        if(col.gameObject.name == "Lwall")
        {
            Destroy(gameObject);
        }
        
        if(col.gameObject.name == "floor")
        {
            Destroy(gameObject);
        }
        
        if(col.gameObject.name == "celing")
        {
            Destroy(gameObject);
        }
    }
    

}
