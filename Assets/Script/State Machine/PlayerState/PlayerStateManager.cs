using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Jump,
    Fall
}

public class PlayerStateManager : StateManager<PlayerState>
{
    private void Awake()
    {
        States.Add(PlayerState.Idle, new PlayerIdleState(this));
        States.Add(PlayerState.Walk, new PlayerWalkState(this));
        States.Add(PlayerState.Run, new PlayerRunState(this));
        States.Add(PlayerState.Jump, new PlayerJumpState(this));
        States.Add(PlayerState.Fall, new PlayerFallState(this));
        CurrentState = States[PlayerState.Idle];
    }
}
