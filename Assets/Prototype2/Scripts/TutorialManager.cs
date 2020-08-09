using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private List<Animator> plusSignAnimations;

    [SerializeField]
    private Animator ballDispenserAnimation;

    [SerializeField]
    public bool ballDispenserPulsing;

    [SerializeField]
    public List<GameObject> ballDispenserTutorialElements;

    [SerializeField]
    public bool plusSignsPulsing;

    [SerializeField]
    public List<GameObject> plusSignTutorialElements;

    private void Start()
    {
        StartPulsePlusSigns();
    }

    public void StartPulsePlusSigns()
    {
        if (plusSignsPulsing == true)
        {
            return;
        }

        plusSignsPulsing = true;

        for (int i = 0; i < plusSignAnimations.Count; i++)
        {
            if(plusSignAnimations[i] != null)
            {
                plusSignAnimations[i].Play("Plus_Sign_Pulse");
            }
        }

        ShowPlusSignsTutorialElements(true);
    }

    public void StopPulsePlusSigns()
    {
        if(plusSignsPulsing == false)
        {
            return;
        }

        plusSignsPulsing = false;

        for (int i = 0; i < plusSignAnimations.Count; i++)
        {
            if (plusSignAnimations[i] != null)
            { 
                plusSignAnimations[i].Play("Plus_Sign_Idle");
            }
        }

        ShowPlusSignsTutorialElements(false);
        StartPulseBallDispenser();
    }

    public void ShowPlusSignsTutorialElements(bool show)
    {
        for (int i = 0; i < plusSignTutorialElements.Count; i++)
        {
            if(plusSignTutorialElements[i] != null)
            {
                plusSignTutorialElements[i].SetActive(show);
            }
        }
    }

    public void StartPulseBallDispenser()
    {
        if (ballDispenserPulsing == true || ballDispenserAnimation == null)
        {
            return;
        }

        ShowBallDispenserTutorialElements(true);
        ballDispenserPulsing = true;
        ballDispenserAnimation.Play("Water_Globe_Pulse");
    }

    public void StopPulseBallDispenser()
    {
        if (ballDispenserPulsing == false || ballDispenserAnimation == null)
        {
            return;
        }

        ballDispenserPulsing = false;
        ballDispenserAnimation.Play("Water_Globe_Idle");
        ShowBallDispenserTutorialElements(false);
    }

    public void ShowBallDispenserTutorialElements(bool show)
    {
        for (int i = 0; i < ballDispenserTutorialElements.Count; i++)
        {
            ballDispenserTutorialElements[i].SetActive(show);
        }
    }
}
