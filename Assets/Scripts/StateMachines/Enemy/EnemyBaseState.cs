using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public bool PlayerInRange()
    {
        Bounds bounds = stateMachine.Collider.bounds;
        float boxSizeMultiplier = 5f;
        float lineOfSight = 5f;
        float faceDir = stateMachine.transform.localScale.x;

        RaycastHit2D raycastHit = Physics2D.BoxCast(
            bounds.center + new Vector3(bounds.extents.x, 0) * boxSizeMultiplier * faceDir, bounds.size*boxSizeMultiplier,
            0f, Vector2.right * faceDir, lineOfSight, LayerMask.GetMask("Ground"));
        Color rayColor;
        
        if(raycastHit.collider != null)
        {
            if (raycastHit.collider.gameObject.CompareTag("Player")) rayColor = Color.green;
            else rayColor = Color.yellow;
        }
        else rayColor = Color.red;

        Debug.DrawRay(bounds.center+  new Vector3 (0, bounds.extents.y)*boxSizeMultiplier, Vector2.right * faceDir * (bounds.size.x * boxSizeMultiplier + lineOfSight), rayColor);
        Debug.DrawRay(bounds.center- new Vector3(0, bounds.extents.y) * boxSizeMultiplier, Vector2.right * faceDir * (bounds.size.x * boxSizeMultiplier + lineOfSight), rayColor);
        Debug.DrawRay(bounds.center - new Vector3(0, bounds.extents.y) * boxSizeMultiplier, Vector2.up * bounds.size.y * boxSizeMultiplier, rayColor);

        return raycastHit.collider.gameObject != null ?
            raycastHit.collider.gameObject.CompareTag("Player")
            : false;
    }
}
