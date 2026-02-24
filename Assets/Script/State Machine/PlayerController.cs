using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Mover Mover;
    public Jumper Jumper;
    public GroundChecker GroundChecker;
    private PlayerStateManager stateMachine;

    public bool JumpPressed { get; private set; }
    public Vector2 MoveInput { get; set; }
    public bool IsGrounded => GroundChecker.CheckIsGrounded();

    private void Awake()
    {
        Mover = GetComponent<Mover>();
        Jumper = GetComponent<Jumper>();
        GroundChecker = GetComponent<GroundChecker>();

        stateMachine = new PlayerStateManager(this); // Initialize the state machine
        if (stateMachine == null)
        {
            Debug.LogError("PlayerStateManager component not found on PlayerController GameObject.");
        }
    }

    private void Start()
    {
        stateMachine.Initialize(PlayerState.Idle); // Enter the initial state
    }

    private void Update()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); // Get horizontal input
        JumpPressed = Input.GetButtonDown("Jump"); // Get jump input
        stateMachine.Tick(); // Update the current state and it should be last
    }

}