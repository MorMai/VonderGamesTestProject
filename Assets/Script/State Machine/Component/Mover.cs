using UnityEngine;

public class Mover : MonoBehaviour, IRequireStats
{
    private Rigidbody2D rb;
    private float speed;
    public void Initialize(EntityData stats)
    {
        rb = GetComponent<Rigidbody2D>();
        speed = stats.moveSpeed;
    }
    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }
}