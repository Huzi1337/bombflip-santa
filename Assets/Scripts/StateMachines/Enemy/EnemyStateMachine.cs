using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{

    [field: SerializeField] public EnemyConfig Config { get; private set; }

    [field: SerializeField] public BoxCollider2D Collider { get; private set; }

    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

    [field: SerializeField] public PlayerStateMachine Player { get; private set; }

    

    void Start()
    {
        
        SwitchState(new EnemyIdleState(this));
    }

    
}
