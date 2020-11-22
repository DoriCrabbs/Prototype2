using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource player;

    [SerializeField]
    private AudioSource music;

    [SerializeField]
    private AudioClip testSound;

    public static AudioPlayer Instance;

    void Awake()
    {
        Instance = this;
        SetMasterVolume(1f);
        SetMusicVolume(0.3f);
        SetSoundVolume(0.1f);
    }

    public void PlaySoundEffect(
        AudioClip clip
        )
    {
        if(player == null || clip == null)
        {
            return;
        }
        player.PlayOneShot(clip);
    }

    public void SetMasterVolume(float volume)
    {
        MasterVolume = volume;
        if (music != null)
        {
            music.volume = MusicVolume * MasterVolume;
        }
        if (player != null)
        {
            player.volume = SoundVolume * MasterVolume;
        }
    }

    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        if(music != null)
        {
            music.volume = MusicVolume * MasterVolume;
        }
    }

    public void SetSoundVolume(float volume)
    {
        SoundVolume = volume;
        if (player != null)
        {
            player.volume = SoundVolume * MasterVolume;
        }
    }

    public void PlayTestSound()
    {
        if (testSound != null)
        {
            player.PlayOneShot(testSound, MasterVolume * SoundVolume);
        }
    }

    public static float MasterVolume;
    public static float MusicVolume;
    public static float SoundVolume;
}
