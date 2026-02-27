using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public EquipmentManager equipmentManager;

    //public Transform aimTransform; // for aiming direction

    private void OnEnable()
    {
        inventoryManager.OnSelectedItemChanged += HandleItemChanged;
    }

    private void OnDisable()
    {
        inventoryManager.OnSelectedItemChanged -= HandleItemChanged;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            UseEquippedItem();
        }
    }

    private void HandleItemChanged(ItemData item)
    {
        if (item != null && item.isEquippable)
            equipmentManager.Equip(item);
        else
            equipmentManager.Equip(null);
    }

    public void UseEquippedItem()
    {
        if (equipmentManager.currentEquippedItem == null)
            return;

        equipmentManager.TryUseItem();
    }
}
