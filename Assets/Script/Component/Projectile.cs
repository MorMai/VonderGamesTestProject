using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Attack))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Attack attackComponent;
    private GameObject owner;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attackComponent = GetComponent<Attack>();
    }

    public void Setup(Vector2 direction, float speed, EntityData shooterStats, GameObject shooter)
    {
        owner = shooter;

        rb.gravityScale = 0f;
        rb.velocity = direction.normalized * speed;

        // Inject shooter stats into Attack
        attackComponent.Initialize(shooterStats);

        // Ignore collision with shooter
        Collider2D myCol = GetComponent<Collider2D>();
        Collider2D ownerCol = owner.GetComponent<Collider2D>();

        if (myCol != null && ownerCol != null)
        {
            Physics2D.IgnoreCollision(myCol, ownerCol);
        }

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == owner)
            return;

        attackComponent.ExecuteAttack(collision.gameObject);
        Destroy(gameObject);
    }
}