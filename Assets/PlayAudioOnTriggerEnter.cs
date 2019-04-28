using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTriggerEnter : MonoBehaviour
{
    public AudioClip clip;
    public bool HasPlayed = false;
    public bool PlayGlobal = true; // If false, plays on player.
    public float Volume;

    private void OnTriggerEnter(Collider other)
    {
        if(HasPlayed == false)
        {
            HasPlayed = true;

            if(PlayGlobal)
                AudioManager.Instance.PlayGlobalClip(clip, 2f, Volume);
            else
                AudioManager.Instance.PlayPlayerClip(clip, Volume);
        }
    }
}
