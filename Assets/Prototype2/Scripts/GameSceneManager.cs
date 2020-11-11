using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using DG;
using DG.Tweening;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro glowingBallsUi;

    [SerializeField]
    private TextMeshPro levelNameUi;

    [SerializeField]
    private PostProcessProfile blur;

    [SerializeField]
    private Material trunkMaterial;

    [SerializeField]
    private string[] levels;

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

    private IEnumerator WinLevel()
    {
        yield return new WaitForSeconds(1);
        //GlowTrunk();
        Debug.Log("Glow or tint tree");
        yield return new WaitForSeconds(1);
        Debug.Log("Blur background");
        //Blur(true);
        yield return new WaitForSeconds(1);
        ShowLevelNameUi(true);
        Debug.Log("Show end scene UI with points, all points, level completed text");
        yield return new WaitForSeconds(10);
        Debug.Log("Load next scene");
        LoadNextScene();
    }

    public void Blur(bool onOff)
    {
        if (blur)
        {
            DepthOfField blurSettings = blur.GetSetting<DepthOfField>();
            if(onOff == true)
            {
                blurSettings.focalLength.Interp(0f, 70f, 1f);
            }
            else
            {
                blurSettings.focalLength.Interp(70f, 0f, 1f);
            }
        }
    }

    public void LoadNextScene()
    {
        if (GameSceneManager.currentLevel < 4)
        {
            ClearLevelName();
            SceneManager.LoadSceneAsync(levels[currentLevel + 1]);
        }
        else
        {
            Debug.Log("You win!");
        }
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

    public void StartWinLevel()
    {
        StartCoroutine(WinLevel());
    }

    public void ClearLevelName()
    {
        if (levelNameUi != null)
        {
            levelNameUi.text = "";
        }
    }

    public void ShowLevelNameUi(bool showHide)
    {
        if(levelNameUi != null)
        {
            levelNameUi.gameObject.SetActive(showHide);
            levelNameUi.DOText("Level " + currentLevel + " Completed! \nPoints on this level: 40 \nLevel of completion: 93%", 5f);
        }
    }

    public void GlowTrunk()
    {
        if(trunkMaterial != null)
        {
            trunkMaterial.DOColor(Color.white, "_EmissionColor", 3f);
        }
    }

    public static GameSceneManager Instance;
    public static int glowingBalls;
    public static int currentLevel;
    public static int essentialGlowingBallsMin;
    public static int essentialGlowingBalls;
}
