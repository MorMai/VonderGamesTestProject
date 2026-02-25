using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    public Mover Mover;

    protected virtual void Awake()
    {
        Mover = GetComponent<Mover>();
        InitializeStateManager();
    }

    protected abstract void InitializeStateManager();
}
