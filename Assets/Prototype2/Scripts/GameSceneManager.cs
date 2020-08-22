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

    public static GameSceneManager Instance;
    public static int glowingBalls;
    public static int currentLevel;
}
