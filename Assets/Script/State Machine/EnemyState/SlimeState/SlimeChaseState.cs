using Unity.VisualScripting;
using UnityEngine;

public class SlimeChaseState : BaseState<EnemyState, EnemyAI>
{
    private float _jumpCheckDistance = 1f; // How close to a wall before jumping
    private float _stoppingDistance = 2.5f;
    private float _forgetPlayerTime = 3f; // Time to forget player after losing sight
    private float _lostSightTimer;

    public SlimeChaseState(EnemyAI context) : base(EnemyState.Chase, context) { }

    public override void EnterState()
    {
        _lostSightTimer = 0f;
    }

    public override void UpdateState()
    {
        Debug.Log("Chasing target: " + Context.Target);
        if (Context.Target == null)
        {
            _lostSightTimer += Time.deltaTime;
            return;
        }

        if (Context.IsFoundPlayer)
        {
            _lostSightTimer = 0f; // Reset if player is visible
        }
        else
        {
            _lostSightTimer += Time.deltaTime;
        }


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
        float diff = Context.Target != null ? Context.Target.position.x - Context.transform.position.x : 0f;
        float distance = Mathf.Abs(diff);

        if (Context.Target == null)
        {
            if (_lostSightTimer >= _forgetPlayerTime)
            {
                Context.IsChasing = false; // Stop chasing if player is lost for too long
                Context.Target = null; // Clear target reference
                return EnemyState.Idle;
            }
            return StateKey;
        }

        if (distance <= _stoppingDistance)
        {
            return EnemyState.Attack;
        }
        // If the player is gone or out of range, go back to Patrol or Idle
        if (!Context.IsFoundPlayer && _lostSightTimer >= _forgetPlayerTime)
        {
            return EnemyState.Idle;
        }

        return StateKey;
    }
}
