using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public InventoryManager inventoryManager;

    public bool CanCraft(CraftingRecipe recipe)
    {
        foreach (IngredientEntry ingredient in recipe.requiredItems.ingredients)
        {
            if (!inventoryManager.HasItemAmount(ingredient.item, ingredient.amount))
                return false;
        }

        return true;
    }

    public void Craft(CraftingRecipe recipe)
    {
        if (!CanCraft(recipe))
        {
            Debug.Log("Not enough materials!");
            return;
        }

        // Remove materials
        foreach (IngredientEntry ingredient in recipe.requiredItems.ingredients)
        {
            inventoryManager.RemoveItemAmount(ingredient.item, ingredient.amount);
        }

        // Add result
        for (int i = 0; i < recipe.resultAmount; i++)
        {
            inventoryManager.AddItem(recipe.result);
        }

        Debug.Log("Crafted: " + recipe.result.itemName);
    }
}
