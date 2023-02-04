using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    [SerializeField] private float crashDelay = 1.5f;
    public event System.Action CrashEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log((int)Mathf.Log(LayerMask.GetMask("Ground"), 2));
        Debug.Log(collision.gameObject.layer);
        Debug.Log(collision);
        if (collision.gameObject.layer == (int)Mathf.Log(LayerMask.GetMask("Ground"), 2) ||
            collision.gameObject.layer == (int)Mathf.Log(LayerMask.GetMask("Obstacle"), 2) ||
            collision.gameObject.layer == (int)Mathf.Log(LayerMask.GetMask("Enemy"), 2))
        {
            //DisableControls();
            StartCoroutine(DelayCrash(crashDelay));
            
        }



    }

    IEnumerator DelayCrash(float time)
    {
        Debug.Log("Started crashing");
        yield return new WaitForSeconds(time);
        Debug.Log("crashed");
        CrashEvent?.Invoke();
    }
}
