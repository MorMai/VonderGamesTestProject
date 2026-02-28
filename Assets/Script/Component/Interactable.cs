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
    public UnityEvent OnInteractStarted;
    public UnityEvent OnInteractFinished;

    public bool canInteract = true;

    public void Interact(Transform interactor)
    {
        if (!canInteract)
            return;

        OnInteractStarted?.Invoke();
        OnInteracted?.Invoke(interactor);
        OnInteractFinished?.Invoke();
    }
}
