using UnityEngine;
public interface IDamageable
{
    void TakeDamage(float amount);
}

public class Health : MonoBehaviour, IRequireStats
{
    private float currentHealth;
    public void Initialize(EntityData stats)
    {
        currentHealth = stats.health;
    }
}
