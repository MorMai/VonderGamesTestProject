using UnityEngine;

public class SlimePatrolState : BaseState<EnemyState, EnemyAI>
{
    private Vector2 _moveDir = Vector2.right;
    private float _wallCheckDist = 0.2f;
    private float _ledgeCheckDist = 1.0f;
    private float _ledgeForwardOffset = 0.5f;
    private float _patrolTime;

    public SlimePatrolState(EnemyAI context) : base(EnemyState.Patrol, context) { }

    public override void EnterState()
    {
        _patrolTime = Random.Range(3f, 6f); 
        // Random move dir
        _moveDir = Random.value > 0.5f ? Vector2.right : Vector2.left;
        Context.UpdateFacing(_moveDir.x);
    }

    public override void UpdateState()
    {
        LayerMask mask = Context.GroundChecker.GroundLayer;
        Bounds bounds = Context.BodyCollider.bounds;

        // Check for Wall
        Vector2 wallOrigin = new Vector2(bounds.center.x + (_moveDir.x * bounds.extents.x),bounds.center.y);
        RaycastHit2D wallHit = Physics2D.Raycast(wallOrigin, _moveDir, _wallCheckDist, mask);

        // Check for Ledge 
        Vector2 ledgeOrigin = new Vector2(bounds.center.x + (_moveDir.x * bounds.extents.x),bounds.min.y);
        Vector2 ledgeStart = ledgeOrigin + (Vector2.right * _moveDir.x * _ledgeForwardOffset);
        RaycastHit2D ledgeHit = Physics2D.Raycast(ledgeStart, Vector2.down, _ledgeCheckDist, mask);

        Debug.DrawRay(wallOrigin, _moveDir * _wallCheckDist, Color.red);
        Debug.DrawRay(ledgeOrigin, Vector2.down * _ledgeCheckDist, Color.blue);

        if (wallHit.collider != null || ledgeHit.collider == null) // If there's a wall ahead or no ground ahead flip direction
        {
            _moveDir *= -1;
            Context.UpdateFacing(_moveDir.x);
        }

        if (_patrolTime > 0)
        {
            _patrolTime -= Time.deltaTime;
        }

        Context.Mover.Move(_moveDir);
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