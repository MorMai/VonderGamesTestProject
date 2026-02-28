using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingStation : MonoBehaviour
{
    public List<CraftingRecipe> stationRecipes;

    public CraftingUI craftingUI;

    public void OpenStation()
    {
        craftingUI.gameObject.SetActive(true);
        craftingUI.Initialize(stationRecipes);
    }

    public void CloseStation()
    {
        craftingUI.gameObject.SetActive(false);
    }
}
