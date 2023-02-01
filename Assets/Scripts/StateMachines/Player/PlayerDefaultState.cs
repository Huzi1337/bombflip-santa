using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class PlayerDefaultState : PlayerBaseState
{
    public PlayerDefaultState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    

    public override void Enter()
    {
        stateMachine.InputHandler.DiveDropEvent += DiveDrop;
        stateMachine.InputHandler.FlipEvent += Flip;
        stateMachine.InputHandler.TapJumpEvent += TapJump;
        stateMachine.InputHandler.JumpEvent+= Jump;
        stateMachine.InputHandler.StartCrouchEvent += Crouch;
        stateMachine.InputHandler.StopCrouchEvent += StopCrouch;

        Debug.Log("Entering default state");
    }

    public override void Tick(float deltaTime)
    {
        Rotate(stateMachine.InputHandler.RotateValue, deltaTime);
        MoveForward(deltaTime);
    }

    public override void Exit()
    {
        stateMachine.InputHandler.DiveDropEvent -= DiveDrop;
        stateMachine.InputHandler.FlipEvent -= Flip;
        stateMachine.InputHandler.TapJumpEvent -= TapJump;
        stateMachine.InputHandler.JumpEvent -= Jump;
        stateMachine.InputHandler.StartCrouchEvent -= Crouch;
        stateMachine.InputHandler.StopCrouchEvent -= StopCrouch;
        Debug.Log("Exiting default state");
    }

    private void DiveDrop()
    {
        if (stateMachine.PowerControl.GetPower() > 0)
        {
            stateMachine.PowerControl.UsePower();
            stateMachine.PlayerRigidbody.AddForce(-stateMachine.transform.up * stateMachine.diveSpeed * stateMachine.transform.localScale.y, ForceMode2D.Impulse);
            stateMachine.SwitchState(new PlayerDiveState(stateMachine));
        }
        else
        {
            Debug.Log("Not Enough Power");
        }

    }
    private void Rotate(Vector2 rotateInput, float deltaTime)
    {
        
            stateMachine.PlayerRigidbody.AddTorque(-rotateInput.x * stateMachine.rotateSpeed * deltaTime);
        
    }

    private void Flip()
    {
        stateMachine.transform.localScale = new Vector2(stateMachine.transform.localScale.x, -stateMachine.transform.localScale.y);
        stateMachine.PlayerRigidbody.velocity = new Vector2(-stateMachine.PlayerRigidbody.velocity.x, stateMachine.PlayerRigidbody.velocity.y);
    }

    private void MoveForward(float deltaTime)
    {
        stateMachine.PlayerRigidbody.velocity += new Vector2(stateMachine.transform.right.x, stateMachine.transform.right.y) * stateMachine.rideSpeed *deltaTime;

    }

    private void TapJump ()
    {
        stateMachine.PlayerRigidbody.AddForce(new Vector2(0, stateMachine.tapJumpSpeed), ForceMode2D.Impulse);
        Debug.Log("Tap jump");
    }

    private void Jump()
    {
        stateMachine.PlayerRigidbody.AddForce(new Vector2(0, stateMachine.jumpSpeed), ForceMode2D.Impulse);
        Debug.Log("Jump");
    }

    private void Crouch ()
    {
        stateMachine.PlayerHitbox.enabled= false;
        stateMachine.DuckHitbox.enabled= true;
        stateMachine.PlayerAnimator.SetBool("isDucking", true);
        Debug.Log("Crouching");
    }

    private void StopCrouch()
    {
        stateMachine.DuckHitbox.enabled = false;
        stateMachine.PlayerHitbox.enabled = true;
        stateMachine.PlayerAnimator.SetBool("isDucking", false);
        Debug.Log("Stopping crouch");
    }

}
