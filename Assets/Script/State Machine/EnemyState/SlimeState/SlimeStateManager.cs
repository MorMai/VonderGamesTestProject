using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeStateManager : StateManager<EnemyState, EnemyAI>
{
    public SlimeStateManager(EnemyAI controller)
    {
        States.Add(EnemyState.Idle, new SlimeIdleState(controller));
        States.Add(EnemyState.Patrol, new SlimePatrolState(controller));
        States.Add(EnemyState.Chase, new SlimeChaseState(controller));
        States.Add(EnemyState.Attack, new SlimeAttackState(controller));
        CurrentState = States[EnemyState.Idle];
    }
}
