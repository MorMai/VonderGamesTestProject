using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState<PlayerState, PlayerController>
{
    public PlayerIdleState(PlayerController context) : base(PlayerState.Idle, context) { }
    public override void EnterState()
    {
        Debug.Log("Enter Idle State");
    }
    public override void UpdateState()
    {

    }
    public override void ExitState()
    {
        Debug.Log("Exit Idle State");
    }
    public override PlayerState GetNextState()
    {
        if (Context.IsMoving)
        {
            return PlayerState.Walk;
        }
        return PlayerState.Idle; // or StateKey
    }
}
