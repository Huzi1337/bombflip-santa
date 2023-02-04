using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        //stateMachine.StartCoroutine(WanderAround());
        Debug.Log("Ajdylej");
    }
    public override void Tick(float deltaTime)
    {
        LookForPlayer();
    }


    public override void Exit()
    {
        stateMachine.StopCoroutine(WanderAround());
        Debug.Log("Enemy exiting idle state");
    }

    private void LookForPlayer()
    {
        if(PlayerInRange())
        {
            Debug.Log("Player detected");
            stateMachine.SwitchState(new EnemyAttackState(stateMachine));
        }
    }

    IEnumerator WanderAround()
    {
        //walk right
        yield return new WaitForSeconds(3f);
        //stop
        yield return new WaitForSeconds(3f);
        //walk left
        yield return new WaitForSeconds(5f);
        //stop
    }
}
