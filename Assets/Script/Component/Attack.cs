using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


public class Attack : MonoBehaviour, IRequireStats
{
    private float minDamage;
    private float maxDamage;
    public void Initialize(EntityData stats)
    {
        minDamage = stats.minDamage;
        maxDamage = stats.maxDamage;
    }
    public void ExecuteAttack(GameObject target)
    {
        float attackDamage = Random.Range(minDamage, maxDamage);

        if(target.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(attackDamage);
            Debug.Log($"Attacked {target.name} for {attackDamage} damage.");
        }
    }
}
