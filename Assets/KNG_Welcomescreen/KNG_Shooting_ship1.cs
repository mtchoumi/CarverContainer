using UnityEngine;

public class KNG_Shooting_ship1 : MonoBehaviour
{
    public GameObject Bullet1;
    public Transform Ship1Child;
    public bool canShoot = true;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!canShoot)
            return;

        GameObject obj = (GameObject)Instantiate(Bullet1, Ship1Child.position, Quaternion.identity);
    }

 
}