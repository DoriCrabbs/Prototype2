using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ContinueGame()
    {
        GameSceneManager.currentLevel = (PlayerPrefs.GetInt("SavedLevel") + 1);
        Debug.Log("Selected level on load: " + GameSceneManager.currentLevel);
        GameSceneManager.glowingBalls = PlayerPrefs.GetInt("GlowingBalls");
        //SceneManager.LoadSceneAsync("Win_Scene");
        Debug.Log($"Load this level at continue: {GameSceneManager.currentLevel}, {GameSceneManager.currentLevel < 5}");
        if (GameSceneManager.currentLevel < 5)
        {
            Debug.Log($"Second Load this level at continue: {GameSceneManager.currentLevel}, {GameSceneManager.currentLevel < 5}");
            SceneManager.LoadSceneAsync(GameSceneManager.currentLevel);
        }else
        {
            SceneManager.LoadSceneAsync("Win_Scene");
        }
    }

    public void StartNewGame()
    {
        DeleteSaveGames();
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
