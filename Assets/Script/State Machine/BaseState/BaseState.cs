using UnityEngine;
using System;

public abstract class BaseState <EState> where EState : Enum // EState is a generic type parameter that must be an enum. This allows me to define states as enums and use them in my state machine
{
    public BaseState(EState key)
    {
        StateKey = key;
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