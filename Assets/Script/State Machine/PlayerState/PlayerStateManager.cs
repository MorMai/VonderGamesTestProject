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

public class PlayerStateManager : StateManager<PlayerState, PlayerController>
{
    public PlayerStateManager(PlayerController controller)
    {
        States.Add(PlayerState.Idle, new PlayerIdleState(controller));
        States.Add(PlayerState.Walk, new PlayerWalkState(controller));
        States.Add(PlayerState.Run, new PlayerRunState(controller));
        States.Add(PlayerState.Jump, new PlayerJumpState(controller));
        States.Add(PlayerState.Fall, new PlayerFallState(controller));
        CurrentState = States[PlayerState.Idle];
    }
}
