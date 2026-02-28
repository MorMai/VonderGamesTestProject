using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropper : MonoBehaviour
{
    [SerializeField] private ItemPool lootPool;

    private InventoryManager _inventory;

    private void Awake()
    {
        _inventory = FindObjectOfType<InventoryManager>();
    }

    // This will be called by UnityEvent
    public void DropLoot()
    {
        if (lootPool == null || _inventory == null)
            return;

        foreach (var entry in lootPool.ingredients)
        {
            for (int i = 0; i < entry.amount; i++)
            {
                _inventory.AddItem(entry.item);
            }
        }
    }
}
