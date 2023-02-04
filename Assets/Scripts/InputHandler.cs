using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;


public class InputHandler : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 RotateValue { get; private set; }
    
    
    private Controls controls;
    public event Action DiveDropEvent, FlipEvent, JumpEvent, TapJumpEvent, StartCrouchEvent, StopCrouchEvent;
    

    private void Awake()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
        Debug.Log("Enejbyl");
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

    
}
