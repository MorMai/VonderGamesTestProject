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

    public void ExecuteAttack(IDamageable target, Vector2 attackerPosition)
    {
        if (target == null)
            return;

        float attackDamage = Mathf.RoundToInt(Random.Range(minDamage, maxDamage));

        target.TakeDamage(attackDamage);

        ApplyKnockback(target, attackerPosition);
    }

    private void ApplyKnockback(IDamageable target, Vector2 attackerPosition)
    {
        if (target is not IKnockbackable knockbackable)
            return;

        MonoBehaviour targetMono = target as MonoBehaviour;

        if (targetMono == null)
            return;

        Vector2 direction = ((Vector2)targetMono.transform.position - attackerPosition).normalized;

        direction.y += knockbackVerticalBoost;

        Vector2 force = direction * knockbackForce;

        knockbackable.ApplyKnockback(force);
    }
}