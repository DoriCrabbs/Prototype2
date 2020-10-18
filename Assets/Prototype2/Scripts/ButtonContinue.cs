using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContinue : MonoBehaviour
{
    [SerializeField]
    private Button button;

    private void Start()
    {
        SetButton();
    }

    private void SetButton()
    {
        if (button != null)
        {
            if (PlayerPrefs.HasKey("HasSavedGame"))
            {
                button.interactable = true;
            }
            else
            {
                button.interactable = false;
            }
        }
    }
}
