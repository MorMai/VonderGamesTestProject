using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover mover;
    private PlayerStateManager stateMachine;
    public bool IsGrounded { get; set; }

    private void Awake()
    {
        mover = GetComponent<Mover>();
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
        stateMachine.Tick(); // Update the current state
    }

    public bool IsMoving => Input.GetAxis("Horizontal") != 0;
}