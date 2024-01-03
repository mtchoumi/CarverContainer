using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DAP_Collide : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Enemy Projectiles"))
        {
            Destroy(col.gameObject);
        }
        else if (col.collider.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            StopCoroutine(DAP_ObjSpawn.SpawnCoroutine);
            SceneManager.LoadScene("DAP_GameOver");
        }
    }
}
