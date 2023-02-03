using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheckPointManager", menuName = "CheckPointManager")]
public class CheckPointManager : ScriptableObject
{
    private Checkpoint ActiveCheckPoint;
    [SerializeField] private Vector2 ActiveCheckPointPosition;



    public void SetActiveCheckPoint(Checkpoint checkpoint)
    {
        if (ActiveCheckPoint != null)
        {
            if (checkpoint.gameObject == ActiveCheckPoint?.gameObject)
            {
                return;
            }
            ActiveCheckPoint.SetColor(Color.gray);
            Debug.Log(GetActiveCheckpointPosition());
        }

        
        
        
        ActiveCheckPoint = checkpoint;
        ActiveCheckPointPosition = ActiveCheckPoint.transform.position;
        ActiveCheckPoint.SetColor(Color.white);

        Debug.Log(GetActiveCheckpointPosition());
    }

    public Vector2 GetActiveCheckpointPosition()
    {
        if (ActiveCheckPointPosition != null)
        {
            return ActiveCheckPointPosition;
        }
                return Vector2.zero;
   
    }
}
