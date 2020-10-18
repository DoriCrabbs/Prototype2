using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> ballEffects;

    public void StopEffects()
    {
        foreach (var particleSystem in ballEffects)
        {
            if(particleSystem != null)
            {
                particleSystem.Stop();
            }
        }
    }
}
