using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] DoorManager doorManager;
    void Start()
    {
        if (doorManager.IsOpen()) gameObject.SetActive(false);
        button.OnClick += OpenDoor;
    }

    private void OpenDoor()
    {
        doorManager.OpenDoor();
        gameObject.SetActive(false);
        button.OnClick -= OpenDoor;
    }
    
}
