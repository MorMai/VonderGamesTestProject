using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image Selector;
    public Color selectedColor;
    public Color notselectedColor;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        Selector.color = selectedColor;
    }
    public void Deselect()
    {
        Selector.color = notselectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            InventoryItem InventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventoryItem.parentAfterDrag = transform; 
        }
    }
}
