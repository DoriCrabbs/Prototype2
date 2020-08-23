﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    [SerializeField]
    private float delay;

    [SerializeField]
    private string[] levels;

    [SerializeField]
    private GameObject finishText;

    private void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadNextScene());
    }


    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(delay);
        if(GameSceneManager.currentLevel < 3)
        {
            SceneManager.LoadSceneAsync(levels[GameSceneManager.currentLevel + 1]);
        }
        else
        {
            finishText.SetActive(true);
        }
    }
}
