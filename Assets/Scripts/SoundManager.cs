using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource TheEndSound, BackgroundSound;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        TheEndSound.PlayOneShot(clip);
    }

    public void PlayBackGroundSound(AudioClip clip)
    {
        BackgroundSound.PlayOneShot(clip);
    }

    public void StopBackGroundSound(AudioClip clip)
    {
        BackgroundSound.Pause();
    }
}
