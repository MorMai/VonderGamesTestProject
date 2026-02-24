using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : BaseState<PlayerState>
{
    private PlayerStateManager _stateManager;
    public PlayerJumpState(PlayerStateManager stateManager) : base(PlayerState.Jump)
    {
        _stateManager = stateManager;
    }

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
