using UnityEngine;

public class SlimeChaseState : BaseState<EnemyState, EnemyAI>
{
    private float _jumpCheckDistance = 1f; // How close to a wall before jumping
    private float _stoppingDistance = 0.5f; 

    public SlimeChaseState(EnemyAI context) : base(EnemyState.Chase, context) { }

    public override void EnterState()
    {
        Debug.Log("Slime is chasing the target!");
    }

    public override void UpdateState()
    {
        if (Context.Target == null) return;

        float diff = Context.Target.position.x - Context.transform.position.x;
        float distance = Mathf.Abs(diff);

        if (distance > _stoppingDistance)
        {
            Vector2 moveDir = diff > 0 ? Vector2.right : Vector2.left;
            Context.UpdateFacing(moveDir.x);

            if (CheckForWall(moveDir) && Context.IsGrounded)
            {
                Context.Jumper.Jump(); // Assuming Jumper has a Jump() method
            }

            Context.Mover.Move(moveDir * 1.5f); // Amplify speed for chasing
        }
        else
        {
            Context.Mover.Stop();
        }
    }

    private bool CheckForWall(Vector2 dir)
    {
        // Query the environment to see if we need to jump
        return Physics2D.Raycast(Context.transform.position, dir, _jumpCheckDistance, Context.GroundChecker.GroundLayer);
    }

    public override void ExitState()
    {
        Context.Mover.Stop();
    }

    public override EnemyState GetNextState()
    {
        // If the player is gone or out of range, go back to Patrol or Idle
        if (!Context.IsFoundPlayer || Context.Target == null)
        {
            return EnemyState.Idle;
        }

        return StateKey;
    }
}