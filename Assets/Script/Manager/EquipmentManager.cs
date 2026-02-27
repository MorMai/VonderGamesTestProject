using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [Header("Setup")]
    public Transform handTransform; // inside character's visual child

    private GameObject currentItemObject;
    public EquippableItem currentEquippedItem { get; private set; }

    public void Equip(ItemData data)
    {
        if (currentItemObject != null)
        {
            Destroy(currentItemObject);
            currentEquippedItem = null;
        }

        if (data != null && data.itemPrefab != null)
        {
            currentItemObject = Instantiate(data.itemPrefab, handTransform);
            currentEquippedItem = currentItemObject.GetComponent<EquippableItem>();

            if (currentEquippedItem != null)
            {
                currentEquippedItem.Initialize(data);
            }
        }
    }

    public void TryUseItem()
    {
        if (currentEquippedItem != null && currentEquippedItem.CanUse())
        {
            currentEquippedItem.Use(this.gameObject, handTransform);
        }
    }
}
