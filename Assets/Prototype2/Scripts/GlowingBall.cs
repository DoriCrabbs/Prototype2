using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingBall : MonoBehaviour
{
    [SerializeField]
    private bool isEssential;

    private void Start()
    {
        if (isEssential
            && GameSceneManager.Instance != null)
        {
            GameSceneManager.Instance.AddEssentialGlowingBallMin();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(GameSceneManager.Instance != null)
        {
            if (isEssential)
            {
                if(GameSceneManager.Instance != null)
                {
                    GameSceneManager.Instance.AddEssentialGlowingBall();
                }
            }
            else
            {
                if (GameSceneManager.Instance != null)
                {
                    GameSceneManager.Instance.AddGlowingBall();
                }
            }
        }
        GameObject.Destroy(gameObject);
    }
}
