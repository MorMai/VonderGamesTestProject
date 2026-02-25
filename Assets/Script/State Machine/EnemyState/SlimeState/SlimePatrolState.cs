using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatrolState : BaseState<EnemyState, EnemyAI>
{
    public SlimePatrolState(EnemyAI context) : base(EnemyState.Patrol, context) { }
    public override void EnterState()
    {
        Debug.Log("Enter Slime Patrol State");
    }
    public override void UpdateState()
    {
        //some logic
    }
    public override void ExitState()
    {
        Debug.Log("Exit Slime Patrol State");
    }
    public override EnemyState GetNextState()
    {
        //some logic
        return StateKey; // or SlimeState.Walk
    }
}
