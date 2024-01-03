using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MH_block : MonoBehaviour
{
        
        private Vector2 hitX;
    private int hitpointY;
      private int hitpointX;
private int PutBlockDownX;
private int PutBlockDownY;
      
public GameObject player;
private Vector2 hardhitPoint;

private int hardhitPointX;
private int hardhitPointX1;

private int hardhitPointX2;

private int hardhitPointY;
public Tilemap tilemap;
public Tile tile;

private Vector2 hardhitPointa;
private int hardhitPointXa;
public bool checkTile = true;
private int hardhitPointX1a;
private int hitpointX1;
private int hardhitPointYa;
public ParticleSystem ps;
public bool check;
private Vector3Int num1;
private Vector3 num2;
private Vector3Int pPosition;
private int hardhitPointX2a;
public float one = 0;
public Sprite SpriteTile;
public int amount;
public static float pressClick;
private float PutBlockDownXf;
private float PutBlockDownYf;
public int checkCount;
bool pressClick1 = true;
public int block;
public static int pressClick2;
public float time;
int[] blockArray;
private Vector3Int Object;

private int highPositionX;

private int highPositionY;
public static bool hy = true;
    // Start is called before the first frame update
    void Start()
    {
      MH_spawn.check1 = true;
      pressClick2 = block;
         block = GetTileAmountSprite(SpriteTile);
         block = GetTileAmountSprite(SpriteTile);
      ps = GetComponent<ParticleSystem>();
          player.GetComponent<MH_movespace>().press = true;
          tilemap = GetComponent<Tilemap>();
           num1 = new Vector3Int(PutBlockDownX,PutBlockDownY - 2,0);
    }
    void OnCollisionEnter2D(Collision2D col){
    
    
        if(col.gameObject.tag == "Enemy"){
          ps.Play();
          print(block);
       
             //Component.FindObjectOfType<MH_blocks>().block--;
            //print(col.GetContact(0).point)
          hitX = col.GetContact(0).point;
          hitpointY = Mathf.RoundToInt(hitX.y - 1);
          hitpointX1 = Mathf.RoundToInt(hitX.x - 1);
          hitpointX = Mathf.RoundToInt(hitX.x);
          ParticleSystem.ShapeModule setting1a = ps.shape;
           setting1a.position = new Vector3(hitpointX,hitpointY,0f);
       
   
         tilemap.SetTile(new Vector3Int(hitpointX,hitpointY,0),null);
         tilemap.SetTile(new Vector3Int(hitpointX1,hitpointY,0),null);
         
        }
       
           if(col.gameObject.tag == "Enemy Projectiles"){
             ps.Play();
             
           hardhitPoint = col.GetContact(0).point;
           hardhitPointX = Mathf.RoundToInt(hardhitPoint.x);
           hardhitPointX1 = Mathf.RoundToInt(hardhitPoint.x + 1);
           hardhitPointX2 = Mathf.RoundToInt(hardhitPoint.x - 1);
           hardhitPointY = Mathf.RoundToInt(hardhitPoint.y - 1);
           tilemap.SetTile(new Vector3Int(hardhitPointX,hardhitPointY,0),null);
           tilemap.SetTile(new Vector3Int(hardhitPointX1,hardhitPointY,0),null);
           tilemap.SetTile(new Vector3Int(hardhitPointX2,hardhitPointY,0),null);
                   ParticleSystem.ShapeModule setting1 = ps.shape;
           setting1.position = new Vector3(hardhitPointX,hardhitPointY,0f);
  
            

         }  
              if(col.gameObject.tag == "HazardAsteruid"){
                  ps.Play();
            
         hardhitPointa = col.GetContact(0).point;
           hardhitPointXa = Mathf.RoundToInt(hardhitPointa.x);
           hardhitPointX1a = Mathf.RoundToInt(hardhitPointa.x + 1);
           hardhitPointYa = Mathf.RoundToInt(hardhitPointa.y - 1);
           hardhitPointX2a = Mathf.RoundToInt(hardhitPointa.x -1);
            tilemap.SetTile(new Vector3Int(hardhitPointXa,hardhitPointYa,0),null);
           tilemap.SetTile(new Vector3Int(hardhitPointX1a,hardhitPointYa,0),null);
            tilemap.SetTile(new Vector3Int(hardhitPointX2a,hardhitPointYa,0),null);
              ParticleSystem.ShapeModule setting = ps.shape;
             setting.position = new Vector3(hardhitPointXa,hardhitPointYa,0f);
        
           
     }
    
    
      
    }
  public int GetTileAmountSprite(Sprite targetSprite){
    
    tilemap.CompressBounds();
     int amount = 0;
 
foreach(Vector3Int position in tilemap.cellBounds.allPositionsWithin){
Tile tile1 = tilemap.GetTile<Tile>(position);
Tile tile2 = tilemap.GetTile<Tile>(Object);
if(tile1 != null){
if(tile1.sprite == targetSprite){
 if(tile1 != tile2){   
checkCount += 1;

amount += 1;
 }
//Debug.Log(pressClick);
    

  }
  

 

}


 }

 return amount;


  }
    // Update is called once per frame
    void Update()
    {

  block = GetTileAmountSprite(SpriteTile);
      //pressClick = checkCount;
    
     if(Input.GetKeyDown("h") && pressClick1 == true){
     
     // GetTileAmountSprite(SpriteTile);
       one = 1;
       check = true;
         if(one == 1 && check == true ){
             //player.GetComponent<MH_movespace>().pressClick++;
      PutBlockDownX = Mathf.RoundToInt(GameObject.Find("charIdle1a").transform.position.x);
      PutBlockDownY = Mathf.RoundToInt(GameObject.Find("charIdle1a").transform.position.y + 2);
       tilemap.SetTile(new Vector3Int(PutBlockDownX,PutBlockDownY,0),tile);
  Tile tile2=  tilemap.GetTile<Tile>(new Vector3Int(PutBlockDownX,PutBlockDownY,0));
   highPositionX = Mathf.RoundToInt(GameObject.Find("HighPosition").transform.position.x);
   highPositionY = Mathf.RoundToInt(GameObject.Find("HighPosition").transform.position.y);
 Object = new Vector3Int(highPositionX,highPositionY,0);
 

pressClick = GetTileAmountSprite(SpriteTile);

       check = false;
one = 0;
hy = false;

       }
      
      
    player.GetComponent<MH_movespace>().one = 0;

   
  }
  if(pressClick2 >= 15){
    pressClick1 = false;
    time += Time.deltaTime;
  }
  if(time >= 5){
  pressClick1 = true;
  time = 0.0f;
  pressClick2 = 0;
}


//for(int x = tilemap.cellBounds.min.x; x < tilemap.cellBounds.max.x; x++){
//for(int y = tilemap.cellBounds.min.y; y < tilemap.cellBounds.max.y; y++){
//for(int z = tilemap.cellBounds.min.z; z < tilemap.cellBounds.max.z; z++){
  

 
 
  /*if(Input.GetKeyUp("h") && pressClick1 == true){
pressClick++;

  }
  if(pressClick >= 20){
    pressClick1 = false;
  }


  if(pressClick1 == false){
time += Time.deltaTime;
if(time >= 6){
  pressClick1 = true;
  time = 0.0f;
}
  }*/
  
//}
//}
//}

    }
}
