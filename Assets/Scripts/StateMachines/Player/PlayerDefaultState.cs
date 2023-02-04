using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDefaultState : PlayerBaseState
{
    public PlayerDefaultState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    PlayerStats playerStats;
    Rigidbody2D playerBody;
    InputHandler EventEmitter;
    public override void Enter()
    {
        playerStats = stateMachine.PlayerStats;
        playerBody = stateMachine.PlayerRigidbody;
        EventEmitter = stateMachine.InputHandler;

        EventEmitter.DiveDropEvent += DiveDrop;
        EventEmitter.FlipEvent += Flip;
        EventEmitter.TapJumpEvent += TapJump;
        EventEmitter.JumpEvent+= Jump;
        EventEmitter.StartCrouchEvent += Crouch;
        EventEmitter.StopCrouchEvent += StopCrouch;

        Debug.Log("Entering default state");
    }

    public override void Tick(float deltaTime)
    {
        Rotate(EventEmitter.RotateValue, deltaTime);
        MoveForward(deltaTime);
        CapVelocity();
    }

    public override void Exit()
    {
        InputHandler EventEmitter = stateMachine.InputHandler;
        EventEmitter.DiveDropEvent -= DiveDrop;
        EventEmitter.FlipEvent -= Flip;
        EventEmitter.TapJumpEvent -= TapJump;
        EventEmitter.JumpEvent -= Jump;
        EventEmitter.StartCrouchEvent -= Crouch;
        EventEmitter.StopCrouchEvent -= StopCrouch;
        Debug.Log("Exiting default state");
    }

    private void DiveDrop()
    {
        if (stateMachine.PowerControl.GetPower() > 0)
        {
            stateMachine.PowerControl.UsePower();
            playerBody.AddForce(-stateMachine.transform.up * playerStats.diveSpeed * stateMachine.transform.localScale.y, ForceMode2D.Impulse);
            stateMachine.SwitchState(new PlayerDiveState(stateMachine));
        }
        else
        {
            Debug.Log("Not Enough Power");
        }

    }
    private void Rotate(Vector2 rotateInput, float deltaTime)
    {

        playerBody.AddTorque(-rotateInput.x * playerStats.rotateSpeed * deltaTime);
        
        
    }

    private void Flip()
    {
        stateMachine.transform.localScale = new Vector2(
            stateMachine.transform.localScale.x,
            -stateMachine.transform.localScale.y);
    }

    private void MoveForward(float deltaTime)
    {
        playerBody.velocity +=
            new Vector2(stateMachine.transform.right.x,
            stateMachine.transform.right.y) * playerStats.rideSpeed *deltaTime;
        

    }

    private void CapVelocity()
    {
        playerBody.velocity = new Vector2(
            Mathf.Min(Mathf.Abs(playerBody.velocity.x), playerStats.maxVelocity) * Mathf.Sign(playerBody.velocity.x),
            playerBody.velocity.y);
    }

    private void TapJump ()
    {
        if(playerBody.IsTouchingLayers(LayerMask.GetMask("Ground")))
        playerBody.AddForce(new Vector2(0, playerStats.tapJumpSpeed), ForceMode2D.Impulse);
        
    }

    private void Jump()
    {
        if (playerBody.IsTouchingLayers(LayerMask.GetMask("Ground")))
            playerBody.AddForce(new Vector2(0, playerStats.jumpSpeed), ForceMode2D.Impulse);
        
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
