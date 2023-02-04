using System;
using UnityEngine;

public class EnemyCollisionManager : MonoBehaviour
{
    [field: SerializeField] public BoxCollider2D VulnerabilityCollider { get; private set; }

    [field: SerializeField] public VulnerabilityPoint VulnerabilityPoint { get; private set; }

    [field: SerializeField] public VulnerabilityType VulnerabilityType { get; private set; }
    void Start()
    {
        VulnerabilityPoint.SetupVulnerabilityPoint(VulnerabilityCollider);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(VulnerabilityType.name)
        {
            case "Contact":
                if (collision.CompareTag("Player")) Destroy(gameObject);
                break;
            case "Dive":
                Type collisionType = collision.gameObject.GetComponent<PlayerStateMachine>()?.GetStateType();
                if (collisionType == typeof(PlayerDiveState)) Destroy(gameObject);
                break;
        }
        
    }

    

}
