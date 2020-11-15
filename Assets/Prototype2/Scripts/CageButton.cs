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

    //[SerializeField]
    //private int levelIndex;

    [SerializeField]
    private Transform energyTarget;

    [SerializeField]
    private Animator wingLeft;

    [SerializeField]
    private Animator wingRight;

    [SerializeField]
    private SpriteRenderer faceHappy;

    [SerializeField]
    private SpriteRenderer faceNeutral;

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
                //StartCoroutine(LoadWinScene());
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
