using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    PlayerInput playerInput;
    Controls playerInputActions;
    PowerControl powerControl;


    [SerializeField] GameObject powerControlUI;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;
    [SerializeField] float tapJumpSpeed = 5f;
    [SerializeField] float rideSpeed = 10f;
    [SerializeField] float diveSpeed = 30f;
  


    private void Awake()
    {
        playerInputActions = new Controls();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
        playerInputActions.Player.Flip.performed += Flip;
        playerInputActions.Player.DiveDrop.performed += DiveDrop;
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
       playerInput = GetComponent<PlayerInput>();
        powerControl = powerControlUI.GetComponent<PowerControl>();
           
    }
    void FixedUpdate()
    {
        MoveForward();
        Rotate(playerInputActions.Player.Rotate.ReadValue<Vector2>());
    }

    void Jump(InputAction.CallbackContext context)
    {
        float jumpVector = jumpSpeed;

        if (context.interaction is TapInteraction) jumpVector = tapJumpSpeed;

        
        myRigidbody.AddForce(new Vector2(0, jumpVector), ForceMode2D.Impulse);


    }

    private void Rotate(Vector2 rotateInput)
    {


        myRigidbody.AddTorque(-rotateInput.x * rotateSpeed * Time.deltaTime);
    }

    private void DiveDrop (InputAction.CallbackContext context)
    {
        if(powerControl.GetPower() > 0) {
            powerControl.UsePower();
            myRigidbody.AddForce(-transform.up*diveSpeed*transform.localScale.y, ForceMode2D.Impulse);
        }
        else
        {
            Debug.Log("Not Enough Power");
        }
    }

    void MoveForward()
    {
        myRigidbody.velocity += new Vector2 (transform.right.x, transform.right.y) * rideSpeed * Time.deltaTime;
        
    }


    void Flip(InputAction.CallbackContext context)
    {
        transform.localScale = new Vector2 (transform.localScale.x, -transform.localScale.y);
        myRigidbody.velocity = new Vector2(-myRigidbody.velocity.x, myRigidbody.velocity.y);
    }


}
