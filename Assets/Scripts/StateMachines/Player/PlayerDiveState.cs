using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiveState : PlayerBaseState
{
    public PlayerDiveState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        
        Debug.Log("Entering dive state");
    }

    public override void Tick(float deltaTime)
    {
       
       if(stateMachine.PlayerRigidbody.IsTouchingLayers(LayerMask.GetMask("Ground"))) DiveDropEnd();
    }

    public override void Exit()
    {
        
        Debug.Log("Exiting dive state");
    }

    private void DiveDropEnd()
    {
        stateMachine.SwitchState(new PlayerDefaultState(stateMachine));
    }

    
}
