using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public EquipmentManager equipmentManager;

    private void OnEnable()
    {
        inventoryManager.OnSelectedItemChanged += HandleItemChanged;
    }

    private void OnDisable()
    {
        inventoryManager.OnSelectedItemChanged -= HandleItemChanged;
    }

    private void HandleItemChanged(ItemData item)
    {
        if (item != null && item.isEquippable)
            equipmentManager.Equip(item);
        else
            equipmentManager.Equip(null);
    }
}
