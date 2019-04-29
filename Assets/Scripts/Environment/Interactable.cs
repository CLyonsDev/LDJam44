using System.Collections;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string Name;

    [Space]
    public bool MustMoveToBeforeInteraction = true;
    public Transform MoveToLoc;
    public float InteractDelay = 0f;
    
    [Space]
    public bool PlayAudioOnInteract = false;
    public AudioClip ClipToPlay;
    public bool PlayGlobal = true;  // If false, play locally on player.
    public float Volume = 1;
    public bool PlayMultiple = false;
    public bool HasPlayed = false;
    public bool DisablesInput;
    private float dur;

    //TODO: GameEvent hook for activation.

    public virtual void Activate() {
        StartCoroutine(ActivateDelay());
    }

    private IEnumerator ActivateDelay()
    {
        yield return new WaitForSeconds(InteractDelay);

        Debug.Log("Interacted with " + Name);
        if (PlayAudioOnInteract && (PlayMultiple == true || HasPlayed == false))
        {
            HasPlayed = true;
            if (ClipToPlay != null)
            {
                if (PlayGlobal)
                {
                    AudioManager.Instance.PlayGlobalClip(ClipToPlay, Volume);
                }
                else
                {
                    AudioManager.Instance.PlayPlayerClip(ClipToPlay, Volume);
                }


                if (DisablesInput)
                {
                    CursorManager.Instance.SetCurstor(CursorManager.CursorStates.deactivated);
                    dur = ClipToPlay.length;
                    StartCoroutine(ReEnableInput());
                }
            }
        }
    }

    public virtual void UsedWith(Item item)
    {
        Debug.Log(Name + " has been used with " + item.Name);
    }

    private IEnumerator ReEnableInput()
    {
        yield return new WaitForSeconds(dur);
        CursorManager.Instance.SetCurstor(CursorManager.CursorStates.normal);
    }
}
