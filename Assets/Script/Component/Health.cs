using UnityEngine;
using UnityEngine.Events;
public interface IDamageable
{
    void TakeDamage(float amount);
}

public class Health : MonoBehaviour, IRequireStats, IDamageable
{
    private float _currentHealth;
    private float _maxHealth;

    public UnityEvent<float,float> OnHealthChanged;
    public UnityEvent OnDeath;
    public void Initialize(EntityData stats)
    {
        _maxHealth = stats.health;
        _currentHealth = _maxHealth;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float amount)
    {
        if(_currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} is already dead. Cannot take more damage.");
            return;
        }

        _currentHealth -= amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); //prevent health below 0
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        Debug.Log($"{gameObject.name} took {amount} damage. Current health: {_currentHealth}");
        if (_currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void ResetHealth()
    {
        _currentHealth = _maxHealth;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
