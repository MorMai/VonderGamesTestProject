using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Consumable : EquippableItem
{
    private ConsumableData consumableData;

    public override void Initialize(ItemData data)
    {
        base.Initialize(data);
        consumableData = data as ConsumableData;

        if (consumableData != null)
            cooldown = consumableData.consumeDelay;
    }

    public override void Use(GameObject user, Transform aimTransform)
    {
        if (!CanUse() || consumableData == null)
            return;

        bool wasConsumed = false;

        // Handle Health
        if (consumableData.healthRestoreAmount > 0)
        {
            if (user.TryGetComponent<Health>(out var health))
            {
                health.Heal(consumableData.healthRestoreAmount);
                wasConsumed = true;
            }
        }

        // Handle Arcane 
        if (consumableData.arcaneRestoreAmount > 0)
        {
            if (user.TryGetComponent<Arcane>(out var arcane))
            {
                arcane.RestoreArcane(consumableData.arcaneRestoreAmount);
                wasConsumed = true;
            }
        }

        if (wasConsumed)
        {
            nextUseTime = Time.time + cooldown;

            // Remove 1 of this item from the inventory
            InventoryManager.Instance.RemoveItemAmount(consumableData, 1);

            Debug.Log($"{consumableData.itemName} consumed and removed from inventory.");
        }
    }
}
