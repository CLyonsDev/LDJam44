using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchpad : Interactable
{
    public AudioClip LockedAudioClip;
    public AudioClip UnlockedAudioClip;

    public Interactable[] InteractablesToActivate;
    public bool IsLocked = false;
    public Item ItemToUnlockThis;
    private bool HasBeenActivated = false;

    public override void Activate()
    {

        if (HasBeenActivated)
            return;

        base.Activate();

        if (IsLocked == true)
        {
            bool hasKey = GameReferences.refs.PlayerInventory.ItemList.Contains(ItemToUnlockThis);
            if (hasKey)
            {
                Debug.Log("Touchpad WAS locked but is now unlocked!");
                AudioManager.Instance.PlayGlobalClip(UnlockedAudioClip, Volume);
                IsLocked = false;
            }
            else
            {
                Debug.Log("Touchpad is locked");
                AudioManager.Instance.PlayGlobalClip(LockedAudioClip, Volume);
                return;
            }
        }

        if (IsLocked == false)
        {
            foreach (Door interactable in InteractablesToActivate)
            {
                interactable.IsLocked = false;
                interactable.Activate();
                HasBeenActivated = true;
            }
        }
    }

    public override void UsedWith(Item item)
    {
        base.UsedWith(item);
        if(item == ItemToUnlockThis)
        {
            Debug.Log("Touchpad unlocked!");
            IsLocked = false;
        }
    }

    public void Unlock()
    {
        IsLocked = false;
        Debug.Log("Unlocked: " + IsLocked);
    }
}
