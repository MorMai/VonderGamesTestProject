using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeChaseState : BaseState<EnemyState, EnemyAI>
{
    public SlimeChaseState(EnemyAI context) : base(EnemyState.Chase, context) { }
    public override void EnterState()
    {
        Debug.Log("Enter Slime Follow State");
    }
    public override void UpdateState()
    {
        //some logic
    }
    public override void ExitState()
    {
        Debug.Log("Exit Slime Follow State");
    }
    public override EnemyState GetNextState()
    {
        //some logic
        return StateKey; // or SlimeState.Follow
    }
}
