using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    public Mover Mover;
    public Jumper Jumper;
    public GroundChecker GroundChecker;
    public Detector Detector;
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
}
