using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem[] leafParticles;

    public void StartLeaves()
    {
        for (int i = 0; i < leafParticles.Length; i++)
        {
            if(this.leafParticles[i] != null)
            {
                var emission = leafParticles[i].emission;
                emission.enabled = true;
            }
        }
    }
}
