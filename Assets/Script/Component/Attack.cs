using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attack : MonoBehaviour, IRequireStats
{
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private float knockbackVerticalBoost = 2f; // Adds a little upward

    private float minDamage;
    private float maxDamage;
    public void Initialize(EntityData stats)
    {
        minDamage = stats.minDamage;
        maxDamage = stats.maxDamage;
    }
    public void ExecuteAttack(GameObject target)
    {
        float attackDamage = Mathf.CeilToInt(Random.Range(minDamage, maxDamage));

        if(target.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(attackDamage);
            Debug.Log($"Attacked {target.name} for {attackDamage} damage.");
        }

        ApplyKnockback(target);
    }

    private void ApplyKnockback (GameObject target)
    {
        Rigidbody2D rb = target.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Calculate direction: Target position - Attacker position
            Vector2 direction = (target.transform.position - transform.position).normalized;
            direction.y += knockbackVerticalBoost;
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        }
    }
}
