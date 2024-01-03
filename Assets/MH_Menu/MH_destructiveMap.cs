using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MH_destructiveMap : MonoBehaviour
{
    public LayerMask projectile;
    public Tilemap tilemap;
    public Tile tile;
    public Tile ore;
    private Vector2 hitX;
    private int hitpointY;
      private int hitpointX;
    public GameObject asteriod;
private int random;
bool isRandom = true;
    public Collider2D collider;
public GameObject prefab;
public ParticleSystem second;

private Vector2 playerX;
private Vector3 newHit;

    private int playerpointX;

    private int playerpointY;
    private int count;

    public GameObject oresHide;

    public Tilemap ores;
    public GridLayout gridLayout;
private string s;
public ParticleSystem ps;


private Vector2 hardhitPoint;

private int hardhitPointX;
private int hardhitPointX1;
public GameObject player;
private int hardhitPointX2;
public float time = 0.0f;
private int hardhitPointY;

private int PutBlockDownX;
private int PutBlockDownY;
bool DestroyAsteriod = true;


public Vector2 hardhitPointa;
public int hardhitPointXa;

public int hardhitPointX1a;

public int hardhitPointYa;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<MH_movespace>().press = true;
        ps = GetComponent<ParticleSystem>();
        ores = GetComponent<Tilemap>();
       second = GetComponent<ParticleSystem>();
       collider = GetComponent<Collider2D>();
        tilemap = GetComponent<Tilemap>();
       
    }
    
    void OnCollisionEnter2D(Collision2D col){
    
    
        if(col.gameObject.tag == "Enemy"){
            ps.Play();
            //print(col.GetContact(0).point)
            hitX = col.GetContact(0).point;
      hitpointY = Mathf.RoundToInt(hitX.y - 1);

          hitpointX = Mathf.RoundToInt(hitX.x);
   
         tilemap.SetTile(new Vector3Int(hitpointX,hitpointY,0),null);
         random = Random.Range(1,8);
              ParticleSystem.ShapeModule _editableShape = ps.shape;

         _editableShape.position = new Vector3(hitpointX,hitpointY,0f);
          ParticleSystem.MainModule setting = ps.main;
             setting.startColor = new Color(123f/255f,85f/255f,31f/255f);
             ps.emissionRate = 30f;
         if(random == 3){
             GameObject obj = (GameObject)Instantiate(prefab,hitX ,transform.rotation);
         }
         
        
    
    
        }

   if(col.gameObject.tag == "Enemy Projectiles"){
           hardhitPoint = col.GetContact(0).point;
           hardhitPointX = Mathf.RoundToInt(hardhitPoint.x);
           hardhitPointX1 = Mathf.RoundToInt(hardhitPoint.x + 1);
           hardhitPointX2 = Mathf.RoundToInt(hardhitPoint.x - 1);
           hardhitPointY = Mathf.RoundToInt(hardhitPoint.y - 1);
           tilemap.SetTile(new Vector3Int(hardhitPointX,hardhitPointY,0),null);
           tilemap.SetTile(new Vector3Int(hardhitPointX1,hardhitPointY,0),null);
           tilemap.SetTile(new Vector3Int(hardhitPointX2,hardhitPointY,0),null);
            
            GameObject.FindWithTag("Enemy Projectiles").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
             GameObject.FindWithTag("Enemy Projectiles").GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            

         }  
     if(col.gameObject.tag == "HazardAsteruid"){
         hardhitPointa = col.GetContact(0).point;
           hardhitPointXa = Mathf.RoundToInt(hardhitPointa.x);
           hardhitPointX1a = Mathf.RoundToInt(hardhitPointa.x + 1);
           hardhitPointYa = Mathf.RoundToInt(hardhitPointa.y - 1);
            tilemap.SetTile(new Vector3Int(hardhitPointXa,hardhitPointYa,0),null);
           tilemap.SetTile(new Vector3Int(hardhitPointX1a,hardhitPointYa,0),null);
           second.Play();
             ParticleSystem.ShapeModule _editableShape = ps.shape;
             ParticleSystem.MainModule setting = ps.main;
             setting.startColor = Color.green;
              ps.emissionRate = 100f;

         _editableShape.position = new Vector3(hardhitPointXa,hardhitPointYa,0f);
     }
        
    }



    // Update is called once per frame
    void Update()
    {
       
         

 
     
    }
}
