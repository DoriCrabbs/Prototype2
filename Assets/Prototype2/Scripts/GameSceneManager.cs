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
    private GlowTrunk trunkGlowAnimation;

    [SerializeField]
    private GlowSwirl swirlGlowAnimation;

    [SerializeField]
    private Leaves leaves;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        ResetLevel();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreOnThisLevel = 0;
        trunkGlowAnimation = FindObjectOfType<GlowTrunk>();
        swirlGlowAnimation = FindObjectOfType<GlowSwirl>();
        leaves = FindObjectOfType<Leaves>();
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
        GlowSwirl();
        yield return new WaitForSeconds(2);
        GlowTrunk();
        yield return new WaitForSeconds(2);
        StartLeaves();
        //Blur(true);
        yield return new WaitForSeconds(1);
        ShowLevelNameUi(true);
        yield return new WaitForSeconds(7);
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
        ClearLevelName();
        Debug.Log("Next scene: " + currentLevel + "Max: " + SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadSceneAsync(currentLevel + 1);
    }

    public void AddGlowingBall(int number)
    {
        glowingBalls += number;
        scoreOnThisLevel += number;
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
            levelNameUi.color = new Color(1f, 1f, 1f, 0f);
            if(currentLevel == 2)
            {
                levelNameUi.text = "Tutorial level completed! Yay! \nScore on this level: " + scoreOnThisLevel + "\nTotal score: " + glowingBalls;
            }
            else
            {
                levelNameUi.text = "Level " + (currentLevel - 2) + " Completed! Yay! \nScore on this level: " + scoreOnThisLevel + "\nTotal score: " + glowingBalls;
            }
            levelNameUi.DOFade(1f, 6f).SetEase(Ease.OutCubic);
        }
    }

    public void GlowTrunk()
    {
        if(trunkGlowAnimation != null)
        {
            trunkGlowAnimation.Glow();
        }
    }

    public void GlowSwirl()
    {
        if (swirlGlowAnimation != null)
        {
            swirlGlowAnimation.Glow();
        }
    }

    public void StartLeaves()
    {
        if (leaves != null)
        {
            leaves.StartLeaves();
        }
    }

    public static GameSceneManager Instance;
    public static int glowingBalls;
    public static int currentLevel;
    public static int essentialGlowingBallsMin;
    public static int essentialGlowingBalls;
    public static int scoreOnThisLevel;
}
