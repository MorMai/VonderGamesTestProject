using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : BaseState<PlayerState, PlayerController>
{
    public PlayerWalkState(PlayerController context) : base(PlayerState.Walk, context) { }

    public override void EnterState()
    {
        Debug.Log("Enter Walk State");
    }

    public override void UpdateState()
    {
        // Walk State logic
    }

    public override void ExitState()
    {
        Debug.Log("Exit Walk State");
    }

    public override PlayerState GetNextState()
    {
        if (Context.IsMoving == false)
        {
            return PlayerState.Idle;
        }
        return StateKey;
    }
}
