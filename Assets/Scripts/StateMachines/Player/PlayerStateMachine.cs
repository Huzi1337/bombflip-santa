using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    
    [SerializeField] public float diveSpeed = 30f;
    [SerializeField] public float rotateSpeed = 10f;
    [SerializeField] public float rideSpeed = 10f;
    [SerializeField] public float jumpSpeed = 10f;
    [SerializeField] public float tapJumpSpeed = 5f;
    [SerializeField] public float maxVelocity = 20f;
    

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
