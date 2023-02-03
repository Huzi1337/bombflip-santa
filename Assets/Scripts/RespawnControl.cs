using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnControl : MonoBehaviour
{
    [field: SerializeField] public InputHandler InputHandler { get; private set; }
    [field: SerializeField] public CheckPointManager CheckPointManager { get; private set; }


    private void Awake()
    {
        if(CheckPointManager.GetActiveCheckpointPosition() != null)
        gameObject.transform.position = CheckPointManager.GetActiveCheckpointPosition();
    }
    void Start()
    {
        InputHandler.CrashEvent += ResetToCheckpoint;
    }

    private void OnDestroy()
    {
        InputHandler.CrashEvent -= ResetToCheckpoint;
    }

    private void ResetToCheckpoint()
    {
        SceneManager.LoadScene(0);
    }
}
