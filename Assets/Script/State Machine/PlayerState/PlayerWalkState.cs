using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : BaseState<PlayerState, PlayerController>
{
    public PlayerWalkState(PlayerController context) : base(PlayerState.Walk, context) { }

    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        // Walk State logic
        Context.Mover.Move(Context.MoveInput);
        //Flip 
        Context.HandleFlip();
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

        if (Context.MoveInput == Vector2.zero)
        {
            return PlayerState.Idle;
        }
        return StateKey;
    }
}
