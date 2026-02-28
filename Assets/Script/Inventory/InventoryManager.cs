using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxInventorySize = 20;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public static InventoryManager Instance { get; private set; }

    public System.Action<ItemData> OnSelectedItemChanged;

    int selectedSlot = -1;

    private void Awake()
    {
        // Simple Singleton setup
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    public void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number <= 3)
            {
                int newSlot = number - 1;
                if (selectedSlot == newSlot)
                {
                    inventorySlots[selectedSlot].Deselect();
                    selectedSlot = -1; // Deselect the current slot
                    OnSelectedItemChanged?.Invoke(null);
                }
                else
                {
                    ChangeSelectedSlot(newSlot);
                }
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
            inventorySlots[selectedSlot].Deselect();

        inventorySlots[newValue].Select();
        selectedSlot = newValue;

        NotifySelectionChanged();
    }

    void NotifySelectionChanged()
    {
        ItemData selectedItem = GetSelectedItem();
        OnSelectedItemChanged?.Invoke(selectedItem);
    }

    public bool AddItem(ItemData item)
    {
        //Find Available Slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxInventorySize && itemInSlot.item.isStackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true; 
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                if (i == selectedSlot)
                {
                    NotifySelectionChanged();
                }
                return true; // Exit after adding the item
            }
        }
        return false;
    }

    public void RemoveItem(ItemData item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item)
            {
                if (itemInSlot.count > 1)
                {
                    itemInSlot.count--;
                    itemInSlot.RefreshCount();
                }
                else
                {
                    Destroy(itemInSlot.gameObject);
                }
                return; // Exit after removing the item
            }
        }
    }

    public ItemData GetSelectedItem()
    {
        if (selectedSlot >= 0)
        {
            InventorySlot slot = inventorySlots[selectedSlot];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null)
            {
                return itemInSlot.item;
            }
        }
        return null; // No item selected
    }

    public void SpawnNewItem(ItemData item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public bool HasItemAmount(ItemData item, int amount) // Check if the inventory has at least a certain amount of a specific item
    {
        int total = 0;

        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && itemInSlot.item == item)
            {
                total += itemInSlot.count;
            }
        }

        return total >= amount;
    }

    public void RemoveItemAmount(ItemData item, int amount) // Remove a specific amount of an item from the inventory
    {
        int remaining = amount;

        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemInSlot != null && itemInSlot.item == item)
            {
                int remove = Mathf.Min(itemInSlot.count, remaining);

                itemInSlot.count -= remove;
                remaining -= remove;

                if (itemInSlot.count <= 0)
                    Destroy(itemInSlot.gameObject);
                else
                    itemInSlot.RefreshCount();

                if (remaining <= 0)
                    return;
            }
        }
    }
}
