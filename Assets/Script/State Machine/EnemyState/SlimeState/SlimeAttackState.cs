using UnityEngine;

public class SlimeAttackState : BaseState<EnemyState, EnemyAI>
{
    private float _attackCooldown = 0.75f; //changing this causes slime aggressive 
    private float _horizontalJumpVelocity = 2.5f;

    private float _cooldownTimer;
    private bool _hasJumped;

    public SlimeAttackState(EnemyAI context)
        : base(EnemyState.Attack, context) { }

    public override void EnterState()
    {
        _horizontalJumpVelocity = Random.Range(1f, 6f); // add some variability
        _cooldownTimer = 0f;
        _hasJumped = false;

        Context.Mover.Stop();
    }

    public override void UpdateState()
    {
        if (Context.Target == null) return;

        _cooldownTimer += Time.deltaTime;

        float diff = Context.Target.position.x - Context.transform.position.x;
        float dir = Mathf.Sign(diff);

        Context.UpdateFacing(dir);

        // Perform jump attack once
        if (!_hasJumped && Context.IsGrounded)
        {
            PerformJumpAttack(dir);
            _hasJumped = true;
        }
    }

    private void PerformJumpAttack(float dir)
    {
        Rigidbody2D rb = Context.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0f, 0f);
        Context.Jumper.Jump();
        rb.velocity = new Vector2(dir * _horizontalJumpVelocity, rb.velocity.y);
    }

    public override void ExitState()
    {
        _hasJumped = false;
    }

    public override EnemyState GetNextState()
    {
        // Wait until landed AND cooldown finished
        if (_hasJumped && Context.IsGrounded && _cooldownTimer >= _attackCooldown)
        {
            return EnemyState.Chase;
        }

        if (!Context.IsFoundPlayer || Context.Target == null)
        {
            return EnemyState.Idle;
        }

        return StateKey;
    }
}