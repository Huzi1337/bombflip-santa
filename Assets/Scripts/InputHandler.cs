using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputHandler : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 RotateValue { get; private set; }
    [SerializeField] private float crashDelay = 1.5f;
    
    private Controls controls;
    public event Action DiveDropEvent, FlipEvent, JumpEvent, TapJumpEvent, StartCrouchEvent, StopCrouchEvent;
    public event Action CrashEvent;

    void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
        
    }

    private void OnDestroy()
    {
        controls?.Player.Disable();
    }

    public void OnDiveDrop(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }
        DiveDropEvent?.Invoke();
    }


    public void OnFlip(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        FlipEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
        if(!context.performed) { return; }
        if (context.interaction is TapInteraction)
        {
            TapJumpEvent?.Invoke();
            return;
        }
        else if (context.interaction is PressInteraction)
        {
            JumpEvent?.Invoke();
        }
        return;
        
    }


    public void OnRotate(InputAction.CallbackContext context)
    {
        RotateValue = context.ReadValue<Vector2>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(LayerMask.GetMask("Obstacle"), 2)) StartCoroutine(DelayCrash(crashDelay));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log((int)Mathf.Log(LayerMask.GetMask("Ground"), 2));
        Debug.Log(collision.gameObject.layer);
        Debug.Log(collision);
        if (collision.gameObject.layer == (int)Mathf.Log(LayerMask.GetMask("Ground"), 2) ||
            collision.gameObject.layer == (int)Mathf.Log(LayerMask.GetMask("Obstacle"), 2))
        {
            //DisableControls();
            StartCoroutine(DelayCrash(crashDelay));
            
        }

        
        
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started) {
            StartCrouchEvent?.Invoke();
            return;
        }
        
        if(context.canceled) StopCrouchEvent?.Invoke();
    }

    public void DisableControls()
    {
        //To be removed with checkpoints introduced
        controls.Disable();
    }

    IEnumerator DelayCrash(float time)
    {
        Debug.Log("Started crashing");
        yield return new WaitForSeconds(time);
        Debug.Log("crashed");
        CrashEvent?.Invoke();
    }
}
