using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro glowingBallsUi;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        ResetLevel();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateUi();
    }

    private void ResetLevel()
    {
        essentialGlowingBalls = 0;
        essentialGlowingBallsMin = 0;
    }

    private void UpdateUi()
    {
        if(glowingBallsUi == null)
        {
            return;
        }
        glowingBallsUi.text = "Sun globes: " + glowingBalls.ToString();
    }

    public void AddGlowingBall(int number)
    {
        glowingBalls += number;
        UpdateUi();
    }

    public void AddEssentialGlowingBallMin()
    {
        essentialGlowingBallsMin++;
        UpdateUi();
    }

    public void AddEssentialGlowingBall()
    {
        essentialGlowingBalls++;
        UpdateUi();
    }

    public static GameSceneManager Instance;
    public static int glowingBalls;
    public static int currentLevel;
    public static int essentialGlowingBallsMin;
    public static int essentialGlowingBalls;
}
