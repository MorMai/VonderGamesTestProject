using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : BaseState<PlayerState>
{
    private PlayerStateManager _stateManager;
    public PlayerRunState(PlayerStateManager stateManager) : base(PlayerState.Run)
    {
        _stateManager = stateManager;
    }

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
