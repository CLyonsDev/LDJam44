using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public bool IsLocked = false;

    public override void Activate()
    {
        if(IsLocked == true)
        {
            Debug.Log("Door is locked.");
            return;
        }
        else
        {
            Destroy(this.gameObject);
        }

        base.Activate();
        // Open door
        Debug.Log("Door is open!");
    }
}
