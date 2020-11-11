using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GlowTrunk : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer trunkRenderer;

    public void Glow()
    {
        if(trunkRenderer != null)
        {
            trunkRenderer.material.DOColor(Color.white, "_EmissionColor", 2f).SetLoops(2, LoopType.Yoyo);
        }
    }
}
