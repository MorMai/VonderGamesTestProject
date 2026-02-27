using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Weapon", menuName = "Inventory/Ranged Weapon Data")]
public class RangedWeaponData : ItemData
{
    [Header("Ranged Stats")]
    public GameObject projectilePrefab; // The bullet we will shoot
    public float fireRate = 0.5f;       // Time between shots
    public float projectileSpeed = 15f;
}
