using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    [SerializeField]
    private float delay;

    [SerializeField]
    private string[] levels;

    private void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadNextScene());
    }


    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Load next level " + (GameSceneManager.currentLevel + 1));
        SceneManager.LoadSceneAsync(levels[GameSceneManager.currentLevel + 1]);
    }
}
