using UnityEngine;
using System;

public abstract class BaseState <EState, TContext> where EState : Enum // EState is a generic type parameter that must be an enum. This allows me to define states as enums and use them in my state machine
{
    // A reference to the context of the state machine, which can be used to access data and methods from the state manager or other components
    // This allows the states to interact with the rest of the game without coupling 
    protected TContext Context; 
    public BaseState(EState key, TContext context)
    {
        StateKey = key;
        Context = context;
    }
    public EState StateKey { get; private set; } 
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract EState GetNextState();

    //virtual for opttional override, abstract for required override
    public virtual void OnTriggerEnter(Collider other) { }
    public virtual void OnTriggerExit(Collider other) { }
    public virtual void OnTriggerStay(Collider other) { }
}