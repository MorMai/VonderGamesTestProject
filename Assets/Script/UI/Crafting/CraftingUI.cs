using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    public CraftingManager craftingManager; 
    public List<CraftingRecipe> availableRecipes;

    public Transform recipeListParent;
    public GameObject recipeButtonPrefab;

    public Transform ingredientListParent;
    public GameObject ingredientUIPrefab;

    private CraftingRecipe selectedRecipe;

    private void Start()
    {
        PopulateRecipeList();
    }
    public void Initialize(List<CraftingRecipe> recipes)
    {
        availableRecipes = recipes;
        PopulateRecipeList();
    }

    void PopulateRecipeList()
    {
        foreach (CraftingRecipe recipe in availableRecipes)
        {
            GameObject go = Instantiate(recipeButtonPrefab, recipeListParent);
            CraftingRecipeUI recipeUI = go.GetComponent<CraftingRecipeUI>();
            recipeUI.Setup(recipe, this);
        }
    }

    public void SelectRecipe(CraftingRecipe recipe)
    {
        selectedRecipe = recipe;
        RefreshIngredientList();
    }

    void RefreshIngredientList()
    {
        foreach (Transform child in ingredientListParent)
            Destroy(child.gameObject);

        foreach (IngredientEntry ingredient in selectedRecipe.requiredItems.ingredients)
        {
            GameObject go = Instantiate(ingredientUIPrefab, ingredientListParent);
            IngredientUI ui = go.GetComponent<IngredientUI>();

            bool hasEnough = craftingManager.inventoryManager
                .HasItemAmount(ingredient.item, ingredient.amount);

            ui.Setup(ingredient, hasEnough);
        }
    }

    public void OnCraftButtonPressed()
    {
        if (selectedRecipe == null)
            return;

        craftingManager.Craft(selectedRecipe);
        RefreshIngredientList();
    }
}
