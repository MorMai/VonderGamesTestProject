using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [Header("Item Data")]
    public string itemName;
    public Sprite itemIcon;
    public string description;
    public bool isStackable;
    public bool isEquippable;

    [Header("Item Model")]
    public GameObject itemPrefab;
}
