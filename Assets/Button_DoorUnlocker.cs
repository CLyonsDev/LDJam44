using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_DoorUnlocker : Interactable
{
    //TODO: FIX
    string DoorToUnlock;

    public override void Activate()
    {
        base.Activate();
        Door[] doors = Resources.FindObjectsOfTypeAll<Door>();
        Debug.Log(doors.Length);
        
        foreach (Door door in doors)
        {
            if (door.transform.name == DoorToUnlock)
            {
                Debug.Log(door.Name);
                Debug.Log("Door " + DoorToUnlock + " unlocked.");
                door.IsLocked = false;
                door.Activate();
                break;
            }
        }
    }
}
