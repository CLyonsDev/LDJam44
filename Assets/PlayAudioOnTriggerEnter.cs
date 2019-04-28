using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    public AudioClip clip;
    public bool HasPlayed = false;
    public bool PlayGlobal = true; // If false, plays on player.
    public float Volume;
    public bool DisablesInput;
    private float dur;
    //TODO: This turns cursor into a "NO" Sign

    private void OnTriggerEnter(Collider other)
    {
        if(HasPlayed == false)
        {
            HasPlayed = true;

            if(PlayGlobal)
                AudioManager.Instance.PlayGlobalClip(clip, 2f, Volume);
            else
                AudioManager.Instance.PlayPlayerClip(clip, Volume);

            if(DisablesInput)
            {
                CursorManager.Instance.SetCurstor(CursorManager.CursorStates.deactivated);
                dur = clip.length;
                StartCoroutine(ReEnableInput());
            }
        }
    }

    private IEnumerator ReEnableInput()
    {
        while(true)
        {
            yield return new WaitForSeconds(dur);
            CursorManager.Instance.SetCurstor(CursorManager.CursorStates.normal);
            break;
        }
    }
}
