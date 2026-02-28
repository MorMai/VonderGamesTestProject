using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    void Interact(Transform interactor);
}

public class Interactable : MonoBehaviour
{
    public UnityEvent<Transform> OnInteracted;
    public UnityEvent<Transform> OnFocusEnter;
    public UnityEvent<Transform> OnFocusExit;

    public bool canInteract = true;

    private void Reset()
    {
        // Ensure trigger collider
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }


    public void Interact(Transform interactor)
    {
        if (!canInteract)
            return;

        OnInteracted?.Invoke(interactor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnFocusEnter?.Invoke(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnFocusExit?.Invoke(other.transform);
        }
    }
}
