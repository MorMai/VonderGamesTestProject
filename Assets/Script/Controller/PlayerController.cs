using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Mover Mover;
    public Jumper Jumper;
    public Transform Visuals;
    public GroundChecker GroundChecker;
    private PlayerStateManager _stateMachine;

    public bool IsRunning { get; set; }
    public float CurrentSpeedMultiplier => IsRunning ? 2.0f : 1.0f;
    public bool JumpPressed { get; private set; }
    public Vector2 MoveInput { get; set; }
    public bool IsGrounded => GroundChecker.CheckIsGround();

    private void Awake()
    {
        Mover = GetComponent<Mover>();
        Jumper = GetComponent<Jumper>();
        GroundChecker = GetComponent<GroundChecker>();
        if (Visuals == null) Visuals = transform.Find("Visuals");
        _stateMachine = new PlayerStateManager(this); // Initialize the state machine
        if (_stateMachine == null)
        {
            Debug.LogError("PlayerStateManager component not found on PlayerController GameObject.");
        }
    }

    private void Start()
    {
        _stateMachine.Initialize(PlayerState.Idle); // Enter the initial state
    }

    private void Update()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); // Get horizontal input
        JumpPressed = Input.GetButtonDown("Jump"); // Check if jump button is pressed
        IsRunning = Input.GetKey(KeyCode.LeftShift); 
        _stateMachine.Tick(); // Update the current state
    }

    public void HandleFlip()
    {
        if (Mathf.Abs(MoveInput.x) > 0.1f)
        {
            Visuals.transform.localScale = new Vector3(Mathf.Sign(MoveInput.x), 1, 1);
        }
    }
}