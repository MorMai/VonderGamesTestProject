using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : BaseState<PlayerState>
{
    private PlayerStateManager _stateManager;
    public PlayerWalkState(PlayerStateManager stateManager) : base(PlayerState.Walk) 
    {
        _stateManager = stateManager;
    }

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
        // some logic
        return StateKey;
    }
}
