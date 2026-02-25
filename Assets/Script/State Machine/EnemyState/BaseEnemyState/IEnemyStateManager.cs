using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Idle,
    Patrol,
    Chase,
    Attack,
    Hurt,
    Dead
}

public interface IEnemyStateManager
{
    void TransitionTo(EnemyState state);
    EnemyState GetCurrentState();
}
