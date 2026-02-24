using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>(); // A dictionary to hold the states of the state machine
    protected BaseState<EState> CurrentState; // The current state of the state machine
    protected bool IsTransitioningState = false;

    void Start()
    {
        CurrentState.EnterState(); 
    }

    void Update()
    {
        EState nextStateKey = CurrentState.GetNextState(); // Get the next state from the current state

        if (IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if(!IsTransitioningState)
        {
            TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(EState StateKey)
    {
        IsTransitioningState = true;
        CurrentState.ExitState(); // Exit the current state
        CurrentState = States[StateKey]; // Set the current state to the new state
        CurrentState.EnterState(); // Enter the new state
        IsTransitioningState = false;
    }

    // Use Unity event, allowing me to handle trigger events in the states
    private void OnTriggerEnter(Collider other) => CurrentState.OnTriggerEnter(other);
    private void OnTriggerStay(Collider other) => CurrentState.OnTriggerStay(other);
    private void OnTriggerExit(Collider other) => CurrentState.OnTriggerExit(other);
}
