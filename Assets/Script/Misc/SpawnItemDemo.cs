using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemDemo : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public ItemData[] itemsToPickup;

    public void Start()
    {
        PickupItem(0); 
    }

    public void PickupItem(int index)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[index]);

        if (result)
        {
            Debug.Log("Picked up: " + itemsToPickup[index].itemName);
        }
        else
        {
            Debug.Log("Inventory full! Could not pick up: " + itemsToPickup[index].itemName);
        }
    }

    public void GetSelectedItem()
    {
        ItemData receivedItem = inventoryManager.GetSelectedItem();

        if (receivedItem != null)
        {
            Debug.Log("Selected Item: " + receivedItem.itemName);
        }
        else
        {
            Debug.Log("No item selected.");
        }
    }
 
}
