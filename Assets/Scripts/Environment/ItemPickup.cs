using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item Item;
    private Inventory PlayerInventory;
    public bool DestroyAfterPickup = true;

    public Item RequiredItem = null;
    public AudioClip FailClip;

    //TODO: GameEvent hook for pickup.

    public override void Activate()
    {
        base.Activate();

        PlayerInventory = GameReferences.refs.PlayerInventory;

        if(PlayerInventory == null)
        {
            Debug.LogError("ItemPickup::Activate() -- PlayerInventory is null");
        }

        if(RequiredItem != null && PlayerInventory.ItemList.Contains(RequiredItem) == false)
        {
            AudioManager.Instance.PlayGlobalClip(FailClip, 0.5f);
            return;
        }

        PlayerInventory.AddItem(Item);
        if(DestroyAfterPickup)
            Destroy(this.gameObject);
    }
}
