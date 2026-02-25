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
        Context.Mover.Move(Context.MoveInput * Context.CurrentSpeedMultiplier);
        Context.HandleFlip();
    }

    public override void ExitState()
    {
        Debug.Log("Exit Run State");
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
        if (Context.MoveInput == Vector2.zero)
        {
            return PlayerState.Idle;
        }
        if (!Context.IsRunning)
        {
            return PlayerState.Walk;
        }
        // some logic
        return StateKey;
    }
}
