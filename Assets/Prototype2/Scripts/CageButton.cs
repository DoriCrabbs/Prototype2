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
    private string winLevelName;

    [SerializeField]
    private int levelIndex;

    [SerializeField]
    private Transform energyTarget;

    private void OnCollisionEnter(Collision collision)
    {
        if (winningText != null)
        {
            winningText.SetActive(true);
        }
        GameSceneManager.currentLevel = levelIndex;
        Time.timeScale = 0f;
        StartCoroutine(LoadWinScene());
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 9
            && energyTarget != null
            && GameSceneManager.essentialGlowingBalls >= GameSceneManager.essentialGlowingBallsMin)
        {
            var rigidBody = collider.gameObject.GetComponent<Rigidbody>();
            if(rigidBody != null)
            {
                Rigidbody.Destroy(rigidBody);
                collider.transform.DOLocalMove(energyTarget.position, 1f);
                collider.SendMessage("StopEffects");
                StartCoroutine(LoadWinScene());
            }
        }
    }

    private IEnumerator LoadWinScene()
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadSceneAsync(winLevelName);
    }
}
