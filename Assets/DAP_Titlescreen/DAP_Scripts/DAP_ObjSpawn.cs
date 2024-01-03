using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class DAP_ObjSpawn : MonoBehaviour
{
    [SerializeField] private GameObject obj1;

    [SerializeField] private GameObject obj2;

    [SerializeField] private GameObject obj3;

    private int _randNum;

    [SerializeField] private Text timeText;

    public static int Time;

    public static Coroutine SpawnCoroutine;
    // Start is called before the first frame update
    

    void Start()
    {
      SpawnCoroutine = StartCoroutine(Spawn());
    }

    // Update is called once per frame
    
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Time++;
            timeText.text ="Time: " + Time.ToString();
            if (Time <= 30) continue;
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 13);
            _randNum = Random.Range(0, 3);
            switch (_randNum)
            {
                case 0:
                    Instantiate(obj1, transform.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(obj2, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(obj3, transform.position, Quaternion.identity);
                    break;
            }

        }
        
    }
}
