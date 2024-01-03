using UnityEngine;

public class KNG_shooting_ship2 : MonoBehaviour
{
    public GameObject Bullet2;
    public Transform Ship2Child;
    public bool canShoot = true;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!canShoot)
            return;

        
        GameObject obj = (GameObject)Instantiate(Bullet2, Ship2Child.position, Quaternion.identity);
    }

 
}