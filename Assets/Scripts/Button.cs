using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public event Action OnClick;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" &&
            collision.gameObject.GetComponent<PlayerStateMachine>().currentState.GetType() == typeof(PlayerDiveState))
        {
            OnClick?.Invoke();
        }
    }
}
