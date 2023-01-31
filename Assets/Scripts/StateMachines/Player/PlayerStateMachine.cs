using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputHandler InputHandler { get; private set; }
    void Start()
    {
        SwitchState(new PlayerDefaultState(this));
    }

}
