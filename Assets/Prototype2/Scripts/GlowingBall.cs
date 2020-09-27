﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingBall : MonoBehaviour
{
    //public void OnCollisionEnter(Collision collision)
    //{
    //    GameSceneManager.Instance.AddGlowingBall();
    //    GameObject.Destroy(gameObject);
    //}

    public void OnTriggerEnter(Collider other)
    {
        if(GameSceneManager.Instance != null)
        {
            GameSceneManager.Instance.AddGlowingBall();
        }
        GameObject.Destroy(gameObject);
    }
}