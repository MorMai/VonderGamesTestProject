using UnityEngine;
using UnityEngine.Events;
public interface IDamageable
{
    void TakeDamage(float amount, Transform attacker);
}

public interface IKnockbackable
{
    void ApplyKnockback(Vector2 force);
}

public class Health : MonoBehaviour, IRequireStats, IDamageable, IKnockbackable
{
    private float _currentHealth;
    private float _maxHealth;

    public UnityEvent<float,float> OnHealthChanged;
    public UnityEvent<Transform> OnDamaged;
    public UnityEvent OnDeath;
    private void Awake()
    {
        // Subscribe destroy logic to death event
        OnDeath.AddListener(HandleDeath);
    }
    private void HandleDeath()
    {
        Destroy(gameObject);
    }

    public void Initialize(EntityData stats)
    {
        _maxHealth = stats.health;
        _currentHealth = _maxHealth;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
    public void TakeDamage(float amount, Transform attacker)
    {
        if(_currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} is already dead. Cannot take more damage.");
            return;
        }

        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); //prevent health below 0
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        OnDamaged?.Invoke(attacker);

        Debug.Log($"{gameObject.name} took {amount} damage. Current health: {_currentHealth}");
        if (_currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void ApplyKnockback(Vector2 force)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
