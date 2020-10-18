using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro glowingBallsUi;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(Instance != null)
        {
            GameObject.Destroy(gameObject);
        }
        Instance = this;
        ResetLevel();
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
        glowingBallsUi.text = "Glowing balls: " + glowingBalls.ToString();
    }

    public void AddGlowingBall()
    {
        glowingBalls++;
        UpdateUi();
    }

    public void AddEssentialGlowingBallMin()
    {
        essentialGlowingBallsMin++;
        Debug.Log($"Essential glowing ball: {essentialGlowingBallsMin}");
        UpdateUi();
    }

    public void AddEssentialGlowingBall()
    {
        essentialGlowingBalls++;
        Debug.Log($"Essential glowing ball: {essentialGlowingBalls}");
        UpdateUi();
    }

    public static GameSceneManager Instance;
    public static int glowingBalls;
    public static int currentLevel;
    public static int essentialGlowingBallsMin;
    public static int essentialGlowingBalls;
}
