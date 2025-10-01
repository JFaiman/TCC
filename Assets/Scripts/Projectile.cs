using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    Vector2 direction;

    private void Start()
    {
        direction = rb.linearVelocity;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.Reflect(direction, collision.contacts[0].normal);
        direction = rb.linearVelocity;
    }
}
