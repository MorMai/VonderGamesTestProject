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
            Target = Detector.CurrentTarget;
        }


        StateMachine?.Tick();
    }

    protected abstract void InitializeStateManager();
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable =
        other.GetComponentInParent<IDamageable>();

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
}
