using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GlowSwirl : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer swirlRenderer;

    public void Glow()
    {
        if(swirlRenderer != null)
        {
            swirlRenderer.material.DOColor(Color.white * 1.5f, "_EmissionColor", 1f).SetLoops(2, LoopType.Yoyo);
        }
    }
}
