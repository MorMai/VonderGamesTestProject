using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class EnemyAI : MonoBehaviour, IStateMachineHost
{
    public Mover Mover;
    public Transform Visuals;
    public Jumper Jumper;
    public GroundChecker GroundChecker;
    public Detector Detector;
    public Attack Attack;
    public StateManager<EnemyState, EnemyAI> StateMachine;
    private Health _health;
    private Transform _detectedTarget;
    public Collider2D BodyCollider { get; private set; }
    public Transform Target { get; set; }
    public bool IsFoundPlayer { get; set; }
    public bool IsChasing { get; set; }
    public bool IsGrounded => GroundChecker.CheckIsGround();

    protected virtual void Awake()
    {
        Mover = GetComponent<Mover>();
        Jumper = GetComponent<Jumper>();
        GroundChecker = GetComponent<GroundChecker>();
        Detector = GetComponent<Detector>();
        Attack = GetComponent<Attack>();
        _health = GetComponent<Health>();
        BodyCollider = GetComponent<Collider2D>();
        if (_health != null) _health.OnDamaged.AddListener(HandleDamaged);
        if (Visuals == null) Visuals = transform.Find("Visuals");
        InitializeStateManager();
    }

    protected virtual void Start()
    {
        StateMachine?.Initialize(EnemyState.Idle);
    }
    protected virtual void Update()
    {
        if (Detector != null)
        {
            IsFoundPlayer = Detector.IsTargetDetected;
            _detectedTarget = Detector.CurrentTarget;

            // Only let detector control target if NOT already aggro
            if (!IsChasing && IsFoundPlayer && _detectedTarget != null)
            {
                Target = _detectedTarget;
            }
        }


        StateMachine?.Tick();
    }

    protected abstract void InitializeStateManager();
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == transform)
            return;

        if (other.GetComponentInParent<EnemyAI>() != null)
            return; // Ignore other enemies, doing this for now but might change later

        IDamageable damageable = other.GetComponentInParent<IDamageable>();

        if (damageable == null)
            return;

        Attack?.ExecuteAttack(damageable, transform.position);   // attacker position
    }

    public string GetCurrentStateName()
    {
        return StateMachine != null ? StateMachine.CurrentStateKey.ToString() : string.Empty;
    }

    public void UpdateFacing(float xDir)
    {
        if (Visuals == null || Mathf.Approximately(xDir, 0)) return;

        Vector3 scale = Visuals.localScale;

        // Check if we need to flip based on direction
        if ((xDir > 0 && scale.x < 0) || (xDir < 0 && scale.x > 0))
        {
            scale.x *= -1;
            Visuals.localScale = scale;
        }
    }

    private void HandleDamaged(Transform attacker)
    {
        if (attacker == null)
            return;

        Target = attacker;
        IsFoundPlayer = true;
        IsChasing = true;

        StateMachine.TransitionToState(EnemyState.Chase);
    }
}
