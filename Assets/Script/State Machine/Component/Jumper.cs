using UnityEngine;

public class Jumper : MonoBehaviour, IRequireStats
{
    private Rigidbody2D rb;
    private float jumpHeight;
    public void Initialize(EntityData stats)
    {
        rb = GetComponent<Rigidbody2D>();
        jumpHeight = stats.jumpHeight;
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
