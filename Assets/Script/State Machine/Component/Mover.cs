using UnityEngine;

public class Mover : MonoBehaviour, IRequireStats
{
    private Rigidbody2D _rb;
    private float _speed;
    public void Initialize(EntityData stats)
    {
        _rb = GetComponent<Rigidbody2D>();
        _speed = stats.moveSpeed;
    }
    public void Move(Vector2 direction)
    {
        _rb.velocity = new Vector2(direction.x * _speed, _rb.velocity.y); //new x, keep y
    }

    public void Stop()
    {
        _rb.velocity = new Vector2(0f, _rb.velocity.y);
    }
}