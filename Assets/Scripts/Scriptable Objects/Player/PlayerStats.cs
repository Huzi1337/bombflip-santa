using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] public float diveSpeed = 30f;
    [SerializeField] public float rotateSpeed = 10f;
    [SerializeField] public float rideSpeed = 10f;
    [SerializeField] public float jumpSpeed = 10f;
    [SerializeField] public float tapJumpSpeed = 5f;
    [SerializeField] public float maxVelocity = 20f;
}
