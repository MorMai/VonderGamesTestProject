using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : EnemyAI
{
    protected override void InitializeStateManager()
    {
        StateMachine = new SlimeStateManager(this);
    }
}
