using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [field: SerializeField] public PlayerStats PlayerStats { get; private set; }
    [field: SerializeField] public BoxCollider2D PlayerHitbox { get; set; }
    [field: SerializeField] public Collider2D DuckHitbox { get; set; }
    [field: SerializeField] public InputHandler InputHandler { get; private set; }
    [field: SerializeField] public PowerControl PowerControl { get; private set; }
    [field: SerializeField] public Rigidbody2D PlayerRigidbody { get; private set; }
    [field: SerializeField] public Animator PlayerAnimator { get; private set; }
    void Start()
    {
        SwitchState(new PlayerDefaultState(this));
    }

}
