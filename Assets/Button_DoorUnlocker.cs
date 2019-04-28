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
        Touchpad[] doors = Resources.FindObjectsOfTypeAll<Touchpad>();
        Debug.Log(doors.Length);
        
        foreach (Touchpad door in doors)
        {
            Debug.Log(door.Name);
            if (door.Name.Equals(DoorToUnlock))
            {
                Debug.Log("Door " + DoorToUnlock + " unlocked.");
                door.Unlock();
                break;
            }
        }
    }
}
