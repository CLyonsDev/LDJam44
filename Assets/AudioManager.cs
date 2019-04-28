using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource PlayerSource;
    public AudioSource GlobalSource;

    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerSource = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<AudioSource>();
        if(PlayerSource==null)
        {
            Debug.LogError("AudioManager::Start() -- Could not find player audiosource. Is the player tagged?");
        }
        GlobalSource = GetComponent<AudioSource>();
    }

    public void PlayGlobalClip(AudioClip clip, float volume = 1.0f)
    {
        GlobalSource.PlayOneShot(clip, volume);
    }

    public void PlayPlayerClip(AudioClip clip, float volume = 1.0f)
    {
        PlayerSource.PlayOneShot(clip, volume);
    }

    public void PlayGlobalClip(AudioClip clip, float delay, float volume = 1.0f)
    {
        GlobalSource.clip = clip;
        GlobalSource.volume = volume;
        GlobalSource.PlayDelayed(delay);
    }

    public void PlayClipAtPoint(AudioClip clip, Vector3 point, float volume = 1.0f)
    {
        AudioSource.PlayClipAtPoint(clip, point, volume);
    }
}
