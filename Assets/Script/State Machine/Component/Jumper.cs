using UnityEngine;

public class Jumper : MonoBehaviour, IRequireStats
{
    private Rigidbody2D _rb;
    private float _jumpHeight;
    public void Initialize(EntityData stats)

    {
        _rb = GetComponent<Rigidbody2D>();
        _jumpHeight = stats.jumpHeight;
    }

    public void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
    }
}