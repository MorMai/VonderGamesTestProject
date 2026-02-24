using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState<PlayerState>
{
    private PlayerStateManager _stateManager;
    public PlayerIdleState(PlayerStateManager stateManager) : base(PlayerState.Idle) // Call the base constructor to set the state key for this state
    {
        _stateManager = stateManager;
    }
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
        // Walk State logic
        return StateKey;
    }
}
