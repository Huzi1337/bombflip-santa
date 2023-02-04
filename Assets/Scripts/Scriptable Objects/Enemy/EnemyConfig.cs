using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] public bool isRanged = true;
    [SerializeField] public string vulnerabilityType;
    [SerializeField] public string specialAttackType;
    [SerializeField] public string shootPattern;
    [SerializeField] public float loseAggroTime = 2f;
    [SerializeField] public float movementSpeed = 5f;
}
