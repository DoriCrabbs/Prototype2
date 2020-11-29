using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManagerCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSceneManagerPrefab;

    private void Awake()
    {
        if(GameSceneManager.Instance == null && gameSceneManagerPrefab != null)
        {
            GameObject.Instantiate(gameSceneManagerPrefab);
        }
    }
}
