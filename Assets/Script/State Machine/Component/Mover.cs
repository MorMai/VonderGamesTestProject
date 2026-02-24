using UnityEngine;

public class Mover : MonoBehaviour, IRequireStats
{
    private float speed;
    public void Initialize(EntityData stats)
    {
        speed = stats.moveSpeed;
    }
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}