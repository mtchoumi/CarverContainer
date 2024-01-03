using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MJB_SpecialScript : MonoBehaviour
{
    public static bool spawnSpecial;

    private GameObject Player;
    [SerializeField] private GameObject SpecialEnemy;
    int layerMask;
    int layerMask2;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        layerMask = 1 << 9;
        layerMask2 = 1 << 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnSpecial == true)
        {
            Vector2 spawnLocation = new Vector2(Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10), Random.Range(Player.transform.position.y - 8, Player.transform.position.y + 8));
            RaycastHit2D hit = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask);
            RaycastHit2D hit2 = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask2);

            while(spawnLocation.x > Player.transform.position.x - 8 && spawnLocation.x < Player.transform.position.x + 8 && spawnLocation.y > Player.transform.position.y - 7 && spawnLocation.y < Player.transform.position.y + 7 || hit.collider != null || hit2.collider != null)
            {
                spawnLocation = new Vector2(Random.Range(Player.transform.position.x - 10, Player.transform.position.x + 10), Random.Range(Player.transform.position.y - 8, Player.transform.position.y + 8));
                hit = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask);
                hit2 = Physics2D.CircleCast(spawnLocation, 0.55f, new Vector2(0,0), 10f, layerMask2);
            }
            transform.position = spawnLocation;
            Instantiate(SpecialEnemy, transform.position, Quaternion.identity);

            spawnSpecial = false;
        }
    }
}
