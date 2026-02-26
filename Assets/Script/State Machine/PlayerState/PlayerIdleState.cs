using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState<PlayerState, PlayerController>
{
    public PlayerIdleState(PlayerController context) : base(PlayerState.Idle, context) { }
    public override void EnterState()
    {
        Context.Mover.Stop();
    }
    public override void UpdateState()
    {

    }
    public override void ExitState()
    {
    }
    public override PlayerState GetNextState()
    {
        if (Context.JumpPressed && Context.IsGrounded)
        {
            return PlayerState.Jump;
        }

        if (!Context.IsGrounded)
        {
            return PlayerState.Fall;
        }

        if (Context.IsRunning && Context.MoveInput != Vector2.zero)
        {
            return PlayerState.Run;
        }

        if (Context.MoveInput != Vector2.zero)
        {
            return PlayerState.Walk;
        }
        return PlayerState.Idle; // or StateKey
    }
}
