using System;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{

    public State currentState { get ; private set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public Type GetStateType()
    {
        return currentState.GetType();
    }
}
