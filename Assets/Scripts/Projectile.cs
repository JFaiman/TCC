using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float projectileLifeTime = 3f;
    Vector2 direction;
    private IEnumerator coroutine;


    public void SetProjectileLife()
    {
        direction = rb.linearVelocity;
        coroutine = DestroyTimer();
        StartCoroutine(coroutine);
    }
    private void OnEnable()
    {
        //direction = rb.linearVelocity;
        //coroutine = DestroyTimer();
        //StartCoroutine(coroutine);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.Reflect(direction, collision.contacts[0].normal);
        direction = rb.linearVelocity;
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(projectileLifeTime);
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
