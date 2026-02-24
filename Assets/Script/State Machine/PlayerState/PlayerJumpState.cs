using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : BaseState<PlayerState, PlayerController>
{
    public PlayerJumpState(PlayerController context) : base(PlayerState.Jump, context) { }

    public override void EnterState()
    {
        Debug.Log("Enter Jump State");
    }

    public override void UpdateState()
    {
        // Jump State logic
    }

    public override void ExitState()
    {
        Debug.Log("Exit Jump State");
    }

    public override PlayerState GetNextState()
    {
        // some logic
        return StateKey;
    }
}
