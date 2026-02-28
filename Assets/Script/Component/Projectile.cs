using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Attack))]
public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private Attack attackComponent;
    private Transform ownerTransform;
    private EntityData ownerStats;
    [SerializeField] private UnityEvent OnCreate;
    [SerializeField] private UnityEvent OnDamage;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        attackComponent = GetComponent<Attack>();
    }

    public void Setup(Vector2 direction, float speed, EntityData shooterStats, Transform shooter)
    {
        ownerTransform = shooter;
        ownerStats = shooterStats;

        rb.gravityScale = 0f;
        rb.velocity = direction.normalized * speed;

        // Inject shooter stats into Attack
        attackComponent.Initialize(ownerStats);
        attackComponent.SetOwner(shooter);

        // Ignore collision with shooter
        Collider2D myCol = GetComponent<Collider2D>();
        Collider2D ownerCol = shooter.GetComponent<Collider2D>();

        if (myCol != null && ownerCol != null)
        {
            Physics2D.IgnoreCollision(myCol, ownerCol);
        }

        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.gameObject == ownerTransform)
            return;

        IDamageable damageable = collision.GetComponentInParent<IDamageable>();

        if (damageable != null)
        {
            //pass to owner stats for damage calculation
            damageable.TakeDamage(Random.Range(ownerStats.minDamage, ownerStats.maxDamage),ownerTransform);
            Destroy(gameObject);
        }
        else
        {
            // Optionally, destroy projectile on hitting non-damageable objects (like walls)
            //Destroy(gameObject);
        }
    }
}