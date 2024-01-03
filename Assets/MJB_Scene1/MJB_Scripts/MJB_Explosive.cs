using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_Explosive : MonoBehaviour
{
    [SerializeField] private float AoE;
    [SerializeField] private float force;

    [SerializeField] private LayerMask layerToHit;
    [SerializeField] private LayerMask layerToHit2;

    [SerializeField] private GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player Projectiles"))
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);

            Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, AoE, layerToHit);

            foreach(Collider2D obj in objects)
            {
                Vector2 direction = obj.transform.position - transform.position;

                if(obj.name == "Enemy(Clone)")
                {
                    obj.GetComponent<MJB_Enemy>().isAffected = true;
                } else if (obj.name == "SpecialEnemy(Clone)")
                {
                    obj.GetComponent<MJB_SpecialEnemy>().isAffected = true;
                }
                obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }

            Collider2D[] objects2 = Physics2D.OverlapCircleAll(transform.position, AoE, layerToHit2);

            foreach(Collider2D obj2 in objects2)
            {
                Vector2 direction = obj2.transform.position - transform.position;

                obj2.GetComponent<MJB_BigEnemy>().isAffected = true;
                obj2.GetComponent<Rigidbody2D>().AddForce(direction * force);
            }

            Destroy(gameObject);
        }
    }
}
