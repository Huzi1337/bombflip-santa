using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] CheckPointManager CheckPointManager;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckPointManager.SetActiveCheckPoint(this);
        }
    }

    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
