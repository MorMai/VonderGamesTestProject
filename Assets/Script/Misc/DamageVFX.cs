using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVFX : MonoBehaviour
{
    [SerializeField] private GameObject damageParticlePrefab;

    public void PlayDamageVFX(Transform attacker)
    {
        if (damageParticlePrefab == null) return;

        Instantiate(damageParticlePrefab, transform.position, Quaternion.identity);
    }
}
