using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        GameSceneManager.currentLevel = PlayerPrefs.GetInt("SavedLevel");
        GameSceneManager.glowingBalls = PlayerPrefs.GetInt("GlowingBalls");
        //SceneManager.LoadSceneAsync("Win_Scene");
        Debug.Log($"Scene: {GameSceneManager.currentLevel}");
        if (GameSceneManager.currentLevel < 4)
        {
            SceneManager.LoadSceneAsync(GameSceneManager.currentLevel + 1);
        }
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

    public void DeleteSaveGames()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void SaveGame(
        int glowingBalls,
        int lastCompletedLevel
        )
    {
        PlayerPrefs.SetInt("HasSavedGame", 1);
        PlayerPrefs.SetInt("GlowingBalls", glowingBalls);
        PlayerPrefs.SetInt("SavedLevel", lastCompletedLevel);
    }
}
