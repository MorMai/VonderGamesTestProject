using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager<EState, TContext> where EState : Enum
{
    public event Action<EState, EState> OnStateChanged;
    protected Dictionary<EState, BaseState<EState,TContext>> States = new Dictionary<EState, BaseState<EState, TContext>>(); // A dictionary to hold the states of the state machine
    protected BaseState<EState, TContext> CurrentState; // The current state of the state machine
    protected bool IsTransitioningState = false;
    public EState CurrentStateKey => CurrentState.StateKey;

    // use this instead of start
    public void Initialize(EState startingState)
    {
        CurrentState = States[startingState]; 
        CurrentState.EnterState(); 
    }

    //use this instead of update
    public void Tick()
    {
        if (IsTransitioningState) return; // If we are currently transitioning states, we don't want to update the current state

        EState nextStateKey = CurrentState.GetNextState(); // Get the next state from the current state

        if (nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else 
        {
            TransitionToState(nextStateKey);
        }
    }

    public void TransitionToState(EState newStateKey)
    {
        IsTransitioningState = true;
        EState previousStateKey = CurrentState.StateKey;
        CurrentState.ExitState(); // Exit the current state
        CurrentState = States[newStateKey]; // Set the current state to the new state
        CurrentState.EnterState(); // Enter the new state
        IsTransitioningState = false;
        OnStateChanged?.Invoke(previousStateKey, newStateKey);
    }

    // Use Unity event, allowing me to handle trigger events in the states
    private void OnTriggerEnter(Collider other) => CurrentState.OnTriggerEnter(other);
    private void OnTriggerStay(Collider other) => CurrentState.OnTriggerStay(other);
    private void OnTriggerExit(Collider other) => CurrentState.OnTriggerExit(other);

    public EState GetCurrentStateKey()
    {
        return CurrentState.StateKey;
    }
}
