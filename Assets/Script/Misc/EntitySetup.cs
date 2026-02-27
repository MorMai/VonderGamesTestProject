using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySetup : MonoBehaviour
{
    [SerializeField] public EntityData stats;

    private void Awake()
    {
        // Get all components in children that implement IRequireStats and initialize them with the provided stats 
        IRequireStats[] statReceivers = GetComponentsInChildren<IRequireStats>();

        foreach (IRequireStats receiver in statReceivers)
        {
            receiver.Initialize(stats);
        }
    }
}
