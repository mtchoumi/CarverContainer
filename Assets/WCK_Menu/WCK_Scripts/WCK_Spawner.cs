using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public struct WCK_Subpool {
    public GameObject obj;
    public int poolSize;
    [System.NonSerialized] public int poolStart;
};

struct WCK_Bullet {
    public int time;
    public Vector3 pos;
    public Quaternion rot;
    public short type;
};

public class WCK_Spawner : MonoBehaviour
{
    // Start is called before the first frame update

	GameObject bulletPrefab;
    [SerializeField] WCK_Subpool[] subpools;
    List<WCK_Bullet> pattern = new List<WCK_Bullet>();
    int timer = 0;
    int adv = 0;
	WCK_TextUpdate textDisplay;
	WCK_Move player;
	byte[] hasPlayed;
	[SerializeField] AudioClip[] sounds;
	[SerializeField] byte[] soundTimeout;
	AudioSource audioSource;
	public static ushort difficulty = 0;
	/* STATIC - WILL EXIST FOREVER */
	/* SHOULD BE 0 IN FINAL GAME */
	
	//public static ObjecstPool Shared;
	public static WCK_Spawner SharedInstance;
	public GameObject[] pooled;
	
	float getX(int hi, int i) {
		float fhi, fi;
		fhi = (float)(hi);
		fi = (float)(i);
		return fi*13.32f/fhi - 6.66f;
	}

	float getY(int hi, int i) {
		float fhi, fi;
		fhi = (float)(hi);
		fi = (float)(i);
		return fi*10.0f/fhi - 5.0f;
	}

	public GameObject GetBullet(short type)
	{
		int i;
        if(type < 0 || type > subpools.Length) {
            return null;
        }
		for(i=subpools[type].poolStart;i<subpools[type].poolStart+subpools[type].poolSize;i++) {
			if(!pooled[i].activeInHierarchy) { /* not active, can be used */
				return pooled[i];
			}
		}
		return null;
	}

	int Comparison(WCK_Bullet x, WCK_Bullet y)
    {
        return x.time-y.time;
    }

    bool SpawnBullet(WCK_Bullet b)
    {
		GameObject spawn;
		spawn = GetBullet(b.type);
		if(!spawn) {
			return false;
		}
		spawn.transform.position = b.pos;
		spawn.transform.rotation = b.rot;
        spawn.SetActive(true);
        return true;
    }

	void Awake()
	{
		SharedInstance = this;
	}

	void SetBullet(int time, float x, float y, float rot, short type) {
        WCK_Bullet b;
        b.time = time;
        b.pos = new Vector3(x,y,0.0f);
        b.rot = Quaternion.Euler(new Vector3(0.0f,0.0f,rot+90.0f));
        b.type = type;
        pattern.Add(b);
    }
	
    void Start()
    {
		int i, j, k, toAdd, size, atk;
		int temp;
		float tempx, tempy;
		const float DEG_TO_RAD = 0.0174532925199f;
        GameObject t;

        textDisplay = Component.FindObjectOfType<WCK_TextUpdate>();
		player = Component.FindObjectOfType<WCK_Move>();
		audioSource = GetComponent<AudioSource>();

		/* SET BULLET PATTERN HERE */

		if(difficulty == 0) {
			temp = 180;
			SetBullet(1,0.0f,3.0f,-90.0f,4);
		} else {
			temp = 0;
		}
		for(i=temp;i<1620;) {
			atk = Random.Range(0,2);
			switch(atk) {
				case 0:
					for(j=0;j<10+difficulty*6;j++) {
						SetBullet(Random.Range(i,i+200),6.66f,Random.Range(-10.0f,10.0f),90.0f,0);
					}
					i += 200;
					break;
				case 1:
					for(j=0;j<10+difficulty*6;j++) {
						SetBullet(Random.Range(i,i+200),-6.66f,Random.Range(-10.0f,10.0f),270.0f,0);
					}
					i += 200;
					break;
			}
		}
			
		for(i=temp;i<1620;i++) {
			atk = Random.Range(0,7);
			toAdd = 0;
			switch(atk) {
			case 0:
				SetBullet(i,0.0f,0.0f,-90.0f,2);
				for(j=0;j<9;j++) {
					SetBullet(i+120,0.0f,0.0f,j * 45.0f,0);
				}
				toAdd = 400;
				break;
			case 1:
				SetBullet(i,0.0f,0.0f,-90.0f,2);
				SetBullet(i,1.5f,0.0f,-90.0f,2);
				SetBullet(i,3.0f,0.0f,-90.0f,2);
				SetBullet(i,4.5f,0.0f,-90.0f,2);
				SetBullet(i,-1.5f,0.0f,-90.0f,2);
				SetBullet(i,-3.0f,0.0f,-90.0f,2);
				SetBullet(i,-4.5f,0.0f,-90.0f,2);
				SetBullet(i,0.0f,1.5f,-90.0f,2);
				SetBullet(i,0.0f,3.0f,-90.0f,2);
				SetBullet(i,0.0f,4.5f,-90.0f,2);
				SetBullet(i,0.0f,-1.5f,-90.0f,2);
				SetBullet(i,0.0f,-3.0f,-90.0f,2);
				SetBullet(i,0.0f,-4.5f,-90.0f,2);
				for(j=0;j<46;j++) {
					SetBullet(120+i+j*4,0.0f,0.0f,2*j + 0.0f,1);
					SetBullet(120+i+j*4,0.0f,0.0f,2*j + 90.0f,1);
					SetBullet(120+i+j*4,0.0f,0.0f,2*j + 180.0f,1);
					SetBullet(120+i+j*4,0.0f,0.0f,2*j + 270.0f,1);
				}
				toAdd = 550;
				break;
			case 2:
				temp = (short)Random.Range(3,6);
				for(j=0;j<temp;j++) {
					SetBullet(i,j*1.5f-6.66f+0.75f,5.0f-0.75f,-90.0f,2);
					SetBullet(i+120,j*1.5f-6.66f+0.75f-0.375f,5.0f-0.75f,180.0f,1);
					SetBullet(i+120,j*1.5f-6.66f+0.75f+0.375f,5.0f-0.75f,180.0f,1);
				}
				for(j=temp+1;j<9;j++) {
					SetBullet(i,j*1.5f-6.66f+0.75f,5.0f-0.75f,-90.0f,2);
					SetBullet(i+120,j*1.5f-6.66f+0.75f-0.375f,5.0f-0.75f,180.0f,1);
					SetBullet(i+120,j*1.5f-6.66f+0.75f+0.375f,5.0f-0.75f,180.0f,1);
				}
				toAdd = 200;
				break;
			case 3:
				for(j=0;j<5;j++) {
					tempx = Mathf.Cos(j*72.0f*DEG_TO_RAD)*3;
					tempy = Mathf.Sin(j*72.0f*DEG_TO_RAD)*3;
					SetBullet(i+j*10,tempx,tempy,-90.0f,2);
					for(k=0;k<1;k++) {
						SetBullet(i+j*10+120,tempx,tempy,Random.Range(0.0f,360.0f),3);
					}
				}
				toAdd = 450;
				break;
			case 4:
				SetBullet(i,0.0f,0.0f,-90.0f,2);
				for(j=0;j<23;j++) {
					SetBullet(120+i+j*8,0.0f,0.0f,8*j + 0.0f,0);
					SetBullet(120+i+j*8,0.0f,0.0f,8*j + 180.0f,0);
				}
				toAdd = 330;
			break;
			case 5:
				for(j=0;j<10;j++) {
					temp = Random.Range(0,720);
					tempx = getX(10,j);
					SetBullet(i+temp,tempx,Mathf.Sin(tempx)*2,-90.0f,2);
					SetBullet(i+temp+120,tempx,Mathf.Sin(tempx)*2,0.0f,3);
				}
				toAdd = 800;
				break;
			case 6:
				SetBullet(i,0.0f,0.0f,-90.0f,2);
				temp = Random.Range(0,2);
				if(temp == 0) {
					for(j=0;j<7;j++) {
						SetBullet(i,-4.5f + 1.5f*j,2.0f,-90.0f,2);
					}
					SetBullet(i,0.0f,0.0f,-90.0f,2);
					for(j=0;j<13;j++) {
						SetBullet(i+120,0.0f,0.0f,j * 15.0f - 90.0f,0);
					}
				}
				if(temp == 1) {
					for(j=0;j<7;j++) {
						SetBullet(i,-4.5f + 1.5f*j,-2.0f,-90.0f,2);
					}
					SetBullet(i,0.0f,0.0f,-90.0f,2);
					for(j=0;j<13;j++) {
						SetBullet(i+120,0.0f,0.0f,j * 15.0f + 90.0f,0);
					}
				}
				toAdd = 400;
				break;
			}
			i += (int)((float)toAdd * (1.0f/((float)(difficulty*2+3)*0.2f)));
		}
		
		/* BULLET PATTERN SET END */
		pattern.Sort(Comparison); 

		hasPlayed = new byte[subpools.Length];
        size = 0;
        for(i=0;i<subpools.Length;i++) {
            subpools[i].poolStart = size;
            size += subpools[i].poolSize;
        }
        pooled = new GameObject[size];

        for(i=0;i<subpools.Length;i++) {
            for(j=subpools[i].poolStart;j<subpools[i].poolStart+subpools[i].poolSize;j++) {
                t = Instantiate(subpools[i].obj);
                t.SetActive(false);
                pooled[j] = t;
            }
        }
    }

    // Update is called once per frame

	void FixedUpdate()
    {
		int i;
		if(timer > 60*27) {
			return;
		}
		if(timer == 60*27) {
			difficulty++; /* increase difficulty every time you win */
			for(i=0;i<pooled.Length;i++) {
				pooled[i].SetActive(false);
			}
			textDisplay.HideScore();
			textDisplay.SetCenterText("END OF LEVEL " + ((int)(difficulty-1)+1) + "\nPREPARE FOR LEVEL " + ((int)(difficulty-1)+2) +"\n HEALTH REFILLED.");
			timer++;
			return;
		}
		for(i=0;i<hasPlayed.Length;i++) {
			if(hasPlayed[i] != 0) {
				hasPlayed[i]--;
			}
		}
        while(timer >= pattern[adv].time && adv < pattern.Count-1) {
            SpawnBullet(pattern[adv]);
			/* sound effect */
			if(hasPlayed[pattern[adv].type]==0) {
				if(sounds[pattern[adv].type]) {
					audioSource.PlayOneShot(sounds[pattern[adv].type],1.0f);
				}
				hasPlayed[pattern[adv].type] = soundTimeout[pattern[adv].type];
			}
            adv++;
        }
        timer++;
    }
}
