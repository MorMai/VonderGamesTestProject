using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttackState : BaseState<SlimeState, EnemyAI>
{
    public SlimeAttackState(EnemyAI context) : base(SlimeState.Attack, context) { }
    public override void EnterState()
    {
        Debug.Log("Enter Slime Attack State");
    }
    public override void UpdateState()
    {
        //some logic
    }
    public override void ExitState()
    {
        Debug.Log("Exit Slime Attack State");
    }
    public override SlimeState GetNextState()
    {
        //some logic
        return StateKey; // or SlimeState.Attack
    }
}
