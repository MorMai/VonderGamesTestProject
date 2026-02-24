using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : BaseState<PlayerState, PlayerController>
{
    private Rigidbody2D rb;
    public PlayerJumpState(PlayerController context) : base(PlayerState.Jump, context) 
    {
        rb = context.GetComponent<Rigidbody2D>();
    }

    public override void EnterState()
    {
        Debug.Log("Enter Jump State");
        // Jump State logic
        Context.Jumper.Jump();
    }

    public override void UpdateState()
    {
        // Allow air control
        Context.Mover.Move(Context.MoveInput * Context.CurrentSpeedMultiplier);
    }

    public override void ExitState()
    {
        Debug.Log("Exit Jump State");
    }

    public override PlayerState GetNextState()
    {
        // If our vertical velocity is near zero or negative, we've reached the peak
        if (rb.velocity.y <= 0f)
        {
            return PlayerState.Fall;
        }

        return PlayerState.Jump;
    }
}
