using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnControl : MonoBehaviour
{
    [field: SerializeField] public PlayerCollisionManager PlayerCollisionManager { get; private set; }
    [field: SerializeField] public CheckPointManager CheckPointManager { get; private set; }


    private void Awake()
    {        
        if (CheckPointManager.GetActiveCheckpointPosition() != null)
        PlayerCollisionManager.gameObject.transform.position = CheckPointManager.GetActiveCheckpointPosition();
    }
    void Start()
    {
        PlayerCollisionManager.CrashEvent += ResetToCheckpoint;
    }

    private void OnDestroy()
    {
        PlayerCollisionManager.CrashEvent -= ResetToCheckpoint;
    }

    private void ResetToCheckpoint()
    {
        SceneManager.LoadScene(0);
    }
}
