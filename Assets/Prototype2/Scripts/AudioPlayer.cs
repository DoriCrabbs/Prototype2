using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource player;
    
    public static AudioPlayer Instance;

    void Awake()
    {
        Instance = this;
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
}
