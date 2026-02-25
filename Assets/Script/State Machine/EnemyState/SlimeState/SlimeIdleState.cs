using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : BaseState<EnemyState, EnemyAI>
{
    private float _idleTime;
    public SlimeIdleState(EnemyAI context) : base(EnemyState.Idle, context) { }
    public override void EnterState()
    {
        Context.Mover.Stop();
        _idleTime = Random.Range(2f, 5f); // Random idle time between 2 and 5 seconds
        Debug.Log("Enter Slime Idle State");
    }
    public override void UpdateState()
    {
        if (_idleTime > 0)
        {
            _idleTime -= Time.deltaTime;
        }
    }
    public override void ExitState()
    {
        Debug.Log("Exit Slime Idle State");
    }
    public override EnemyState GetNextState()
    {
        if(Context.Target != null)
        {
            return EnemyState.Chase; 
        }
        if (_idleTime <= 0)
        {
            return EnemyState.Patrol; // Transition to Patrol after idling
        }
        //some logic
        return StateKey; // or SlimeState.Idle
    }
}
