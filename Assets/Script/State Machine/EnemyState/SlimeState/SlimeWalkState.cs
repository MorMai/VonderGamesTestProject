using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWalkState : BaseState<SlimeState, EnemyAI>
{
    public SlimeWalkState(EnemyAI context) : base(SlimeState.Walk, context) { }
    public override void EnterState()
    {
        Debug.Log("Enter Slime Walk State");
    }
    public override void UpdateState()
    {
        //some logic
    }
    public override void ExitState()
    {
        Debug.Log("Exit Slime Walk State");
    }
    public override SlimeState GetNextState()
    {
        //some logic
        return StateKey; // or SlimeState.Walk
    }
}
