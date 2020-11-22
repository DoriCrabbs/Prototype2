using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusSign : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro forceText;

    [SerializeField]
    private int defaultFforce = 1;

    [SerializeField]
    private int force;

    [SerializeField]
    private Bumper bumper;

    [SerializeField]
    private TutorialManager tutorialManager;

    [SerializeField]
    private List<GameObject> forceBalls;

    private void Start()
    {
        SetForce(defaultFforce);
        UpdateText();
    }

    private void AddForce()
    {
        if (force < 5)
        {
            force++;
        }
        else
        {
            force = 1;
        }
        UpdateText();
        UpdateBumper();
    }

    private void SetForce(int newFforce)
    {
        force = newFforce;
        UpdateText();
        UpdateBumper();
    }

    private void UpdateText()
    {
        for (int i = 0; i < forceBalls.Count; i++)
        {
            if(i < force)
            {
                if(forceBalls[i] != null)
                {
                    forceBalls[i].SetActive(true);
                }
            }
            else
            {
                if (forceBalls[i] != null)
                {
                    forceBalls[i].SetActive(false);
                }
            }
        }
        if (forceText == null)
        {
            return;
        }
        forceText.text = force.ToString();
    }

    private void OnMouseDown()
    {
        AddForce();
        
        if(tutorialManager == null)
        {
            return;
        }

        tutorialManager.StopPulsePlusSigns();
    }

    private void UpdateBumper()
    {
        if (bumper == null)
        {
            return;
        }

        bumper.SetForce(force);
    }

}
