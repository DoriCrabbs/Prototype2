using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundImpactPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip impactSound;

    private void OnCollisionEnter(Collision collision)
    {
        if(AudioPlayer.Instance == null || impactSound == null)
        {
            return;
        }
        AudioPlayer.Instance.PlaySoundEffect(impactSound);
    }
}
