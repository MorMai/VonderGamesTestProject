using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CraftingRecipeUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;

    private CraftingRecipe recipe;
    private CraftingUI craftingUI;

    public void Setup(CraftingRecipe recipe, CraftingUI ui)
    {
        this.recipe = recipe;
        this.craftingUI = ui;

        icon.sprite = recipe.result.itemIcon;
        nameText.text = recipe.result.itemName;

        GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        craftingUI.SelectRecipe(recipe);
    }
}
