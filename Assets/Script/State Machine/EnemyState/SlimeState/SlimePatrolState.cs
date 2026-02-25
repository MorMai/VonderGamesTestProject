using UnityEngine;

public class SlimePatrolState : BaseState<EnemyState, EnemyAI>
{
    private Vector2 _moveDir = Vector2.right;
    private float _wallCheckDist = 0.6f;
    private float _ledgeCheckDist = 1.0f;
    private float _ledgeForwardOffset = 0.5f;
    private float _patrolTime;

    public SlimePatrolState(EnemyAI context) : base(EnemyState.Patrol, context) { }

    public override void EnterState()
    {
        _patrolTime = Random.Range(3f, 6f); 
        // Set initial direction based on localScale 
        _moveDir = Context.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    }

    public override void UpdateState()
    {
        LayerMask mask = Context.GroundChecker.GroundLayer;
        Vector2 pos = Context.transform.position;

        // Check for Wall
        RaycastHit2D wallHit = Physics2D.Raycast(pos, _moveDir, _wallCheckDist, mask);

        // Check for Ledge 
        Vector2 ledgeStart = pos + (Vector2.right * _moveDir.x * _ledgeForwardOffset);
        RaycastHit2D ledgeHit = Physics2D.Raycast(ledgeStart, Vector2.down, _ledgeCheckDist, mask);

        Debug.DrawRay(pos, _moveDir * _wallCheckDist, Color.red);
        Debug.DrawRay(ledgeStart, Vector2.down * _ledgeCheckDist, Color.blue);

        if (wallHit.collider != null || ledgeHit.collider == null) // If there's a wall ahead or no ground ahead flip direction
        {
            Flip();
        }

        if (_patrolTime > 0)
        {
            _patrolTime -= Time.deltaTime;
        }

        Context.Mover.Move(_moveDir);
    }

    private void Flip()
    {
        _moveDir *= -1f;
        Vector3 scale = Context.transform.localScale;
        scale.x *= -1f;
        Context.transform.localScale = scale;
    }

    public override void ExitState() => Context.Mover.Stop();

    public override EnemyState GetNextState()
    {
        if (Context.IsFoundPlayer)
        {
            return EnemyState.Chase;
        }
        if (_patrolTime <= 0)
        {
            return EnemyState.Idle; 
        }
        return StateKey;
    }
}