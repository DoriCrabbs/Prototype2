using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG;
using DG.Tweening;

public class CageButton : MonoBehaviour
{
    [SerializeField]
    private GameObject winningText;

    [SerializeField]
    private float delay;

    [SerializeField]
    private float wingAnimationDelay;

    [SerializeField]
    private string winLevelName;

    [SerializeField]
    private Transform energyTarget;

    [SerializeField]
    private Animator wingLeft;

    [SerializeField]
    private Animator wingRight;

    [SerializeField]
    private Animator armLeft;

    [SerializeField]
    private SpriteRenderer armLeftSprite;

    [SerializeField]
    private Animator armRight;

    [SerializeField]
    private SpriteRenderer armRightSprite;

    [SerializeField]
    private Animator body;

    [SerializeField]
    private SpriteRenderer faceHappy;

    [SerializeField]
    private SpriteRenderer faceNeutral;

    [SerializeField]
    private GameObject facePivot;

    [SerializeField]
    private SpriteRenderer swirlPivot;

    [SerializeField]
    private GameObject wingPivot;


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Ball"
            && energyTarget != null
            && GameSceneManager.essentialGlowingBalls >= GameSceneManager.essentialGlowingBallsMin)
        {
            var rigidBody = collider.gameObject.GetComponent<Rigidbody>();
            if(rigidBody != null)
            {
                StartCoroutine(PlayHappyWingAnimation());
                GameSceneManager.currentLevel = SceneManager.GetActiveScene().buildIndex;
                Debug.Log("Set level index: " + GameSceneManager.currentLevel);
                Rigidbody.Destroy(rigidBody);
                collider.transform.DOLocalMove(energyTarget.position, 1f);
                collider.SendMessage("StopEffects");
                MainMenu.SaveGame(GameSceneManager.glowingBalls, GameSceneManager.currentLevel);
                ChangeFace(true);
                if(GameSceneManager.Instance != null)
                {
                    GameSceneManager.Instance.StartWinLevel();
                }
            }
        }
    }

    private IEnumerator LoadWinScene()
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadSceneAsync(winLevelName);
    }

    private IEnumerator PlayHappyWingAnimation()
    {
        yield return new WaitForSeconds(wingAnimationDelay);
        if(wingLeft != null)
        {
            wingLeft.Play("Left_Wing_Happy");
        }
        if (wingRight != null)
        {
            wingRight.Play("Right_Wing_Happy");
        }
        if (body != null)
        {
            body.CrossFade("Mushin_Happy", 0.25f);
        }
        if (armRight != null)
        {
            armRight.Play("Arm_Right_Happy");
        }
        if (armLeft != null)
        {
            armLeft.Play("Arm_Left_Happy");
        }
    }

    public void ShowFace()
    {
        if(facePivot != null)
        {
            facePivot.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
            facePivot.SetActive(true);
            facePivot.transform.DOScale(new Vector3(1f, 1f, 1f), 1f);
        }
    }

    public void ShowSwirl()
    {
        if (swirlPivot != null)
        {
            swirlPivot.gameObject.SetActive(true);
        }
    }

    public void ShowWings()
    {
        if (wingPivot != null)
        {
            wingPivot.transform.localScale = new Vector3(0.01f, 0.01f, 1f);
            wingPivot.SetActive(true);
            wingPivot.transform.DOScale(new Vector3(0.25f, 0.25f, 1f), 2f);
        }
    }

    public void ShowArms()
    {
        if (armLeftSprite != null)
        {
            armLeftSprite.gameObject.SetActive(true);
            armLeftSprite.DOFade(1f, 2f).From(0.01f);
        }
        if (armRightSprite != null)
        {
            armRightSprite.gameObject.SetActive(true);
            armRightSprite.DOFade(1f, 2f).From(0.01f);
        }
    }

    private void ChangeFace(bool happy)
    {
        if(faceHappy != null && faceNeutral != null)
        {
            if (happy)
            {
                faceHappy.DOColor(new Color(1f, 1f, 1f, 1f), 3f);
                faceNeutral.DOColor(new Color(1f, 1f, 1f, 0f), 3f);
            }
            else
            {
                faceHappy.DOColor(new Color(1f, 1f, 1f, 0f), 3f);
                faceNeutral.DOColor(new Color(1f, 1f, 1f, 1f), 3f);
            }
        }
    }
}
