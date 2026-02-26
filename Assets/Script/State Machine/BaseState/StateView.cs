using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class StateView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stateLabel;
    private IStateMachineHost stateHost;
    private string lastState;

    [Serializable]
    public class StateVisual
    {
        public string StateName;
    }

    private void Awake()
    {
        stateHost = GetComponent<IStateMachineHost>();

        if (stateHost == null)
        {
            Debug.LogWarning($"No IStateMachineHost found on {gameObject.name}");
            enabled = false;
            return;
        }

        lastState = stateHost.GetCurrentStateName();
        ApplyVisual(lastState);
    }

    private void Update()
    {
        string currentState = stateHost.GetCurrentStateName(); // Get the current state name from the state machine host

        if (currentState != lastState)
        {
            lastState = currentState;
            ApplyVisual(currentState);
        }
    }

    private void ApplyVisual(string stateName)
    {
        if (stateLabel != null)
            stateLabel.text = stateName;
    }
}