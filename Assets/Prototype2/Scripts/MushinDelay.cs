using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushinDelay : MonoBehaviour
{
    [SerializeField]
    private GameObject mushin;

    [SerializeField]
    private float delay = 5f;

    void Start()
    {
        StartCoroutine(ShowMushinWithDelay());
    }

    private IEnumerator ShowMushinWithDelay()
    {
        yield return new WaitForSeconds(delay);
        if(mushin != null)
        {
            mushin.SetActive(true);
        }
    }
}
