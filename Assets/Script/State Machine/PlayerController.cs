using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Mover Mover;
    private PlayerStateManager stateMachine;

    public Vector2 MoveInput { get; set; }
    public bool IsGrounded { get; set; }

    private void Awake()
    {
        Mover = GetComponent<Mover>();
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

        stateMachine.Tick(); // Update the current state
    }
}