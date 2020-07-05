using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlusSign : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro forceText;

    [SerializeField]
    private int force;

    [SerializeField]
    private Bumper bumper;

    private void Start()
    {
        force = 1;
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

    private void UpdateText()
    {
        if (forceText == null)
        {
            return;
        }
        forceText.text = force.ToString();
    }

    private void OnMouseDown()
    {
        AddForce();
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
