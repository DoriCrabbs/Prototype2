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
    private GameObject ballCreatorImage;

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

        if (currentBall.transform.position.y < lowerLimit)
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
