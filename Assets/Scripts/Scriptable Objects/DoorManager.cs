using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorManager", menuName = "DoorManager")]
public class DoorManager : ScriptableObject
{
    [SerializeField] private bool isOpen = false;


    public void OpenDoor()
    {
        isOpen= true;
    }

    public void CloseDoor()
    {
        isOpen= false;
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
