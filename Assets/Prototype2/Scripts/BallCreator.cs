using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject currentBall;

    [SerializeField]
    private float lowerLimit;

    [SerializeField]
    private float rightLimit;

    [SerializeField]
    private GameObject ballCreatorImage;

    [SerializeField]
    private TutorialManager tutorialManager;

    private void Update()
    {
        CheckBallPosition();
    }

    private void CheckBallPosition()
    {
        if(currentBall == null)
        {
            return;
        }

        if (currentBall.transform.position.y < lowerLimit || currentBall.transform.position.x > rightLimit)
        {
            Destroy(currentBall);
            currentBall = null;
            ShowBallCreatorImage(true);
        }
    }

    private void OnMouseDown()
    {
        if (ballPrefab == null)
        {
            return;
        }
        
        if (currentBall != null)
        {
            return;
        }

        currentBall = GameObject.Instantiate(ballPrefab);
        currentBall.transform.position = transform.position;

        ShowBallCreatorImage(false);

        if(tutorialManager == null)
        {
            return;
        }

        tutorialManager.StopPulseBallDispenser();
    }

    private void ShowBallCreatorImage(bool show)
    {
        if (ballCreatorImage == null)
        {
            return;
        }

        ballCreatorImage.SetActive(show);
    }
}
