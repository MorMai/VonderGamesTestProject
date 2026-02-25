using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : BaseState<EnemyState, EnemyAI>
{
    public SlimeIdleState(EnemyAI context) : base(EnemyState.Idle, context) { }
    public override void EnterState()
    {
        Debug.Log("Enter Slime Idle State");
    }
    public override void UpdateState()
    {
        //some logic
    }
    public override void ExitState()
    {
        Debug.Log("Exit Slime Idle State");
    }
    public override EnemyState GetNextState()
    {
        //some logic
        return StateKey; // or SlimeState.Idle
    }
}
