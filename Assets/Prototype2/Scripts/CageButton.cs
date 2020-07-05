using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CageButton : MonoBehaviour
{
    [SerializeField]
    private GameObject winningText;

    [SerializeField]
    private float delay;

    [SerializeField]
    private string winLevelName;

    private void OnCollisionEnter(Collision collision)
    {
        if (winningText == null)
        {
            return;
        }
        winningText.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(LoadWinScene());
    }

    private IEnumerator LoadWinScene()
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadSceneAsync(winLevelName);
    }
}
