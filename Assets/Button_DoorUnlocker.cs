using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_DoorUnlocker : Interactable
{
    public string DoorToUnlock;
    public bool HasBeenUsed = false;
    public Transform otherButton;

    public override void Activate()
    {
        if (HasBeenUsed)
            return;

        //Door[] doors = //Resources.FindObjectsOfTypeAll<Door>();
        Door[] doors = Resources.FindObjectsOfTypeAll<Door>();
        Debug.Log(doors.Length);
        
        foreach (Door door in doors)
        {
            //Debug.Log(string.Format("{0} :: {1}", door.Name, DoorToUnlock));
            if (door.Name == DoorToUnlock)
            {
                //Debug.Log(door.Name);
                Debug.Log("Door " + DoorToUnlock + " unlocked.");
                door.IsLocked = false;
                door.Activate();
                HasBeenUsed = true;
                otherButton.GetComponent<Button_DoorUnlocker>().HasBeenUsed = true;
                break;
            }
        }

        base.Activate();
    }
}
