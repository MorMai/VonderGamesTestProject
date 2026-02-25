using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlimeState
{
    Idle,
    Walk,
    Attack
}

public class SlimeStateManager : StateManager<SlimeState, EnemyAI>
{
    public SlimeStateManager(EnemyAI controller)
    {
        States.Add(SlimeState.Idle, new SlimeIdleState(controller));
        States.Add(SlimeState.Walk, new SlimeWalkState(controller));
        States.Add(SlimeState.Attack, new SlimeAttackState(controller));
        CurrentState = States[SlimeState.Idle];
    }
}
