using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : BaseState<PlayerState, PlayerController>
{
    public PlayerFallState(PlayerController context) : base(PlayerState.Fall, context) { }

    public override void EnterState()
    {
        Debug.Log("Enter Fall State");
    }

    public override void UpdateState()
    {
        // Move while falling
        Context.Mover.Move(Context.MoveInput);
    }

    public override void ExitState()
    {
        Debug.Log("Exit Fall State");
    }

    public override PlayerState GetNextState()
    {
        // some logic
        if(Context.IsGrounded)
        {
            if (Context.MoveInput != Vector2.zero)
            {
                return PlayerState.Walk;
            }
            else
            {
                return PlayerState.Idle;
            }
        }
        return StateKey;
    }
}
