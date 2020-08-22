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

    [SerializeField]
    private int levelIndex;

    private void OnCollisionEnter(Collision collision)
    {
        if (winningText != null)
        {
            winningText.SetActive(true);
        }
        Debug.Log("Set level to " + levelIndex);
        GameSceneManager.currentLevel = levelIndex;
        Time.timeScale = 0f;
        StartCoroutine(LoadWinScene());
    }

    private IEnumerator LoadWinScene()
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadSceneAsync(winLevelName);
    }
}
