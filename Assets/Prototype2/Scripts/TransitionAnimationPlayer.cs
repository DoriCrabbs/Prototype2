using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private Animator[] transitionAnimations;

    private void Awake()
    {
        for (int i = 0; i < GameSceneManager.currentLevel; i++)
        {
            if(transitionAnimations[i] != null)
            {
                transitionAnimations[i].gameObject.SetActive(true);
                transitionAnimations[i].Play("Image_Idle");
            }
        }
        transitionAnimations[GameSceneManager.currentLevel].gameObject.SetActive(true);
        transitionAnimations[GameSceneManager.currentLevel].Play("Image_Fade_In");
    }
}
