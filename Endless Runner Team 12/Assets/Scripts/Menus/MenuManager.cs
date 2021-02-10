using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string gameScene, creditsScene;

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
