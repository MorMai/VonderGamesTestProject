using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/ConsumableData")]
public class ConsumableData : ItemData
{
    public int healthRestoreAmount;
    public float arcaneRestoreAmount;
    public float consumeDelay = 1.0f;
}