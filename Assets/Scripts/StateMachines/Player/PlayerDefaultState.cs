using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultState : PlayerBaseState
{
    private float timer = 5f;

    public PlayerDefaultState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    

    public override void Enter()
    {
        Debug.Log("enter");
    }

    public override void Tick(float deltaTime)
    {
        timer -= deltaTime;
        Debug.Log(timer);
        if(timer <= 0f)
        {
            stateMachine.SwitchState(new PlayerDefaultState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("exit");
    }

    
}
