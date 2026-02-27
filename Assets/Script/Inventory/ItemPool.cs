using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Pool", menuName = "Crafting/Item Pool")]
public class ItemPool : ScriptableObject
{
    public List<IngredientEntry> ingredients;
}

[System.Serializable]
public class IngredientEntry
{
    public ItemData item;
    public int amount;
}