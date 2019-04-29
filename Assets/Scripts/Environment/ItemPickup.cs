using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item Item;
    private Inventory PlayerInventory;
    public bool DestroyAfterPickup = true;

    //TODO: GameEvent hook for pickup.

    public override void Activate()
    {
        base.Activate();

        PlayerInventory = GameReferences.refs.PlayerInventory;

        if(PlayerInventory == null)
        {
            Debug.LogError("ItemPickup::Activate() -- PlayerInventory is null");
        }
        PlayerInventory.AddItem(Item);
        if(DestroyAfterPickup)
            Destroy(this.gameObject);
    }
}
