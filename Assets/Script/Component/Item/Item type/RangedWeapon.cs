using UnityEngine;

public class RangedWeapon : EquippableItem
{
    public Transform firePoint;

    private RangedWeaponData rangedData;
    public override void Use(GameObject user, Transform aimTransform)
    {
        throw new System.NotImplementedException();
    }
}