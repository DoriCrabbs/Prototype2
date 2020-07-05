using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject currentBall;

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

        if (currentBall.transform.position.y < -14f)
        {
            Destroy(currentBall);
            currentBall = null;
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
    }
}
