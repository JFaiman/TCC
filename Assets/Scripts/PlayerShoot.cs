using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform[] firePoints;
    [SerializeField] GameObject projectilePreFabb;
    [SerializeField] float projectileForce = 20f;

    bool lookingLeft = true;

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
                else if (lookingLeft)
                {
                    Shoot(firePoints[0]);
                }
                else
                {
                    Shoot(firePoints[3]);
                }
            }
        }
        if(Input.GetAxisRaw("Horizontal") == -1 && lookingLeft)
        {
            lookingLeft = false;
        }
        if (Input.GetAxisRaw("Horizontal") == 1 && !lookingLeft)
        {
            lookingLeft = true;
        }
    }

    
    void Shoot(Transform firePoint)
    {
        //GameObject projectile = Instantiate(projectilePreFabb, firePoint.position, firePoint.rotation);
        if (projectilePreFabb.activeSelf == false)
        {
            projectilePreFabb.SetActive(true);
            projectilePreFabb.transform.position = firePoint.position;
            projectilePreFabb.transform.rotation = firePoint.rotation;
            Rigidbody2D rb = projectilePreFabb.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
            projectilePreFabb.GetComponent<Projectile>().SetProjectileLife();
        }
    }
    
}
