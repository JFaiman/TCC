using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform[] firePoints;
    [SerializeField] GameObject projectilePreFabb;
    [SerializeField] float projectileForce = 20f;



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(Input.GetAxisRaw("Horizontal") == 1)
            {
                if (Input.GetAxisRaw("Vertical") == 1)
                {
                    Shoot(firePoints[2]);
                }
                else if (Input.GetAxisRaw("Vertical") == -1)
                {
                    Shoot(firePoints[1]);
                }
                else
                {
                    Shoot(firePoints[0]);
                }
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                if (Input.GetAxisRaw("Vertical") == 1)
                {
                    Shoot(firePoints[5]);
                }
                else if (Input.GetAxisRaw("Vertical") == -1)
                {
                    Shoot(firePoints[4]);
                }
                else
                {
                    Shoot(firePoints[3]);
                }
            }
            else
            {
                if (Input.GetAxisRaw("Vertical") == 1)
                {
                    Shoot(firePoints[6]);
                }
                else if (Input.GetAxisRaw("Vertical") == -1)
                {
                    Shoot(firePoints[7]);
                }
            }
        }
    }

    
    void Shoot(Transform firePoint)
    {
        GameObject projectile = Instantiate(projectilePreFabb, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up *projectileForce, ForceMode2D.Impulse);
    }
    
}
