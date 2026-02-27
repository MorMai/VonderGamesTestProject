using UnityEngine;

public class RangedWeapon : EquippableItem
{
    public Transform firePoint;

    private RangedWeaponData rangedData;

    public override void Initialize(ItemData data)
    {
        base.Initialize(data);

        rangedData = data as RangedWeaponData;

        if (rangedData != null)
            cooldown = rangedData.fireRate;
    }

    public override void Use(GameObject user, Transform aimTransform)
    {
        if (!CanUse() || rangedData == null)
            return;

        if (!user.TryGetComponent<EntitySetup>(out var setup))
            return;

        if (!user.TryGetComponent<Arcane>(out var arcane))
            return;

        if (!arcane.TrySpendArcane(rangedData.arcaneCost))
            return;

        float faceDirection = Mathf.Sign(aimTransform.lossyScale.x); // include parent scale direction
        Vector2 shootDirection = new Vector2(faceDirection, 0);

        GameObject bulletObj = Instantiate(
            rangedData.projectilePrefab,
            firePoint.position,
            Quaternion.identity
        );

        if (bulletObj.TryGetComponent<Projectile>(out var projectile))
        {
            projectile.Setup(shootDirection, rangedData.projectileSpeed, setup.stats, user.transform);
        }

        nextUseTime = Time.time + cooldown;
    }
}