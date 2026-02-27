using UnityEngine;

public class Attack : MonoBehaviour, IRequireStats
{
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private float knockbackVerticalBoost = 2f;

    private float minDamage;
    private float maxDamage;

    public void Initialize(EntityData stats)
    {
        if (stats == null)
            return;

        minDamage = stats.minDamage;
        maxDamage = stats.maxDamage;
    }

    public void ExecuteAttack(GameObject target)
    {
        if (target == null)
            return;

        float attackDamage = Mathf.RoundToInt(Random.Range(minDamage, maxDamage));

        if (target.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(attackDamage);
            Debug.Log($"Attacked {target.name} for {attackDamage} damage.");
        }

        ApplyKnockback(target);
    }

    private void ApplyKnockback(GameObject target)
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();

        if (rb == null)
            return;

        Vector2 direction = (target.transform.position - transform.position).normalized;
        direction.y += knockbackVerticalBoost;

        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
    }
}