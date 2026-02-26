using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public TextMeshProUGUI countText;

    [HideInInspector] public ItemData item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void Start()
    {
        InitialiseItem(item);
    }
    public void InitialiseItem(ItemData newItem)
    {
        item = newItem;
        image.sprite = item.itemIcon; 
        RefreshCount();
    } 

    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool TextActive = count > 1;
        countText.gameObject.SetActive(TextActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false; // Allow raycasts to pass through while dragging
        parentAfterDrag = transform.parent; // Store the original parent to return to if needed
        transform.SetParent(transform.root); // Move to root to avoid being clipped by other UI elements
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; // Move the item with the cursor
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true; // Re-enable raycasts when done dragging
        transform.SetParent(parentAfterDrag); // Return to original parent (or new parent)
    }
}
