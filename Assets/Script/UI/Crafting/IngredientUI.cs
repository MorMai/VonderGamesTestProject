using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngredientUI : MonoBehaviour
{
    public TMP_Text nameText;
    public Image icon;

    public void Setup(IngredientEntry ingredient, bool hasEnough)
    {
        nameText.text = ingredient.item.itemName + " x" + ingredient.amount;
        icon.sprite = ingredient.item.itemIcon;

        nameText.color = hasEnough ? Color.green : Color.red;
    }
}
