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
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y); //new x, keep y
    }

    public void Stop()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
}