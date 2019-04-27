using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string Name;

    //TODO: GameEvent hook for activation.
    
    public virtual void Activate() {
        Debug.Log("Interacted with " + Name);
    }

    public virtual void UsedWith(Item item)
    {
        Debug.Log(Name + " has been used with " + item.Name);
    }
}
