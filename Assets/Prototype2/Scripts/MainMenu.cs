using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame(15, "Level_2");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void ContinueGame()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("SavedLevel"));
    }

    public void StartNewGame()
    {
        SceneManager.LoadSceneAsync("Intro");
    }

    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

    public static void SaveGame(
        int glowingBalls,
        string lastCompletedLevel
        )
    {
        PlayerPrefs.SetInt("HasSavedGame", 1);
        PlayerPrefs.SetInt("GlowingBalls", glowingBalls);
        PlayerPrefs.SetString("SavedLevel", lastCompletedLevel);
    }
}
