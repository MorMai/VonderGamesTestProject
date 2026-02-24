using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : BaseState<PlayerState, PlayerController>
{
    public PlayerRunState(PlayerController context) : base(PlayerState.Run, context) { }
    public override void EnterState()
    {
        Debug.Log("Enter Run State");
    }

    public override void UpdateState()
    {
        // Run State logic
    }

    public override void ExitState()
    {
        Debug.Log("Exit Run State");
    }

    public override PlayerState GetNextState()
    {
        // some logic
        return StateKey;
    }
}
