using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiveState : PlayerBaseState
{
    public PlayerDiveState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        stateMachine.InputHandler.DiveDropEndEvent += DiveDropEnd;
        Debug.Log("Entering dive state");
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Diving");
    }

    public override void Exit()
    {
        stateMachine.InputHandler.DiveDropEndEvent -= DiveDropEnd;
        Debug.Log("Exiting dive state");
    }

    private void DiveDropEnd()
    {
        stateMachine.SwitchState(new PlayerDefaultState(stateMachine));
    }

    
}
