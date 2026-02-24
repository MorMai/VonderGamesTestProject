using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : BaseState<PlayerState>
{
    private PlayerStateManager _stateManager;
    public PlayerFallState(PlayerStateManager stateManager) : base(PlayerState.Fall)
    {
        _stateManager = stateManager;
    }

    public override void EnterState()
    {
        Debug.Log("Enter Fall State");
    }

    public override void UpdateState()
    {
        // Fall State logic
    }

    public override void ExitState()
    {
        Debug.Log("Exit Fall State");
    }

    public override PlayerState GetNextState()
    {
        // some logic
        return StateKey;
    }
}
