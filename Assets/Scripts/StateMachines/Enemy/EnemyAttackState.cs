using System.Collections;
using UnityEngine;


public class EnemyAttackState : EnemyBaseState
{
   
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    private EnemyConfig config;
    private Transform transform;
    public bool isLosingAggro;

    public override void Enter()
    {
        isLosingAggro = false;
        Debug.Log("Entering attack State");
        transform = stateMachine.transform;
        config = stateMachine.Config;
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log("Arghhhhh!");
        FacePlayer();
        MoveTowardsPlayer(deltaTime);
        if (!PlayerInRange())
        {
            if (!isLosingAggro)
            {
                Debug.Log(isLosingAggro);
                stateMachine.StartCoroutine(LoseAggro());
                isLosingAggro = true;
            }
            
        }
        else
        {
                stateMachine.StopCoroutine(LoseAggro());
                isLosingAggro = false;       
        }
    }

    public override void Exit()
    {
        stateMachine.StopAllCoroutines();
    }

    private void FacePlayer()
    {
        float playerPosition = stateMachine.Player.transform.position.x;
        float currentPosition = transform.position.x;
        Vector3 localScale = transform.localScale;
        if (playerPosition < currentPosition)
        {
            
            transform.localScale = new Vector3(-1, localScale.y, localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, localScale.y, localScale.z);
        }
    }

    private void MoveTowardsPlayer(float deltaTime)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(stateMachine.Player.transform.position.x, transform.position.y), config.movementSpeed * deltaTime);
    }

    IEnumerator LoseAggro()
    {
        Debug.Log("Losing aggro");
        yield return new WaitForSeconds(config.loseAggroTime);
        stateMachine.SwitchState(new EnemyIdleState(stateMachine));
    }
}
