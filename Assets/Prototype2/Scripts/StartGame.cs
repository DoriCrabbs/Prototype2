using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartTutorial()
    {
        SceneManager.LoadSceneAsync("Level_Tutorial");
        this.gameObject.SetActive(false);
    }
}
