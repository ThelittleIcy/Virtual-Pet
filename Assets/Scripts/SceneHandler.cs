using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // The name of the Menu Scene.
    [SerializeField]
    private string m_menuScene = "MenuScene";
    // The name of the Game Scene.
    [SerializeField]
    private string m_gameScene = "MainScene";
    // The name of the Credits Scene.
    [SerializeField]
    private string m_creditsScene = "CreditsScene";
    /// <summary>
    /// Returns to the menu scene.
    /// </summary>
    public void ToMenu()
    {
        SceneManager.LoadScene(m_menuScene);
    }
    /// <summary>
    /// Returns to the Game Scene.
    /// </summary>
    public void ToGame()
    {
        SceneManager.LoadScene(m_gameScene);
    }
    /// <summary>
    /// Returns to the Credits Scene.
    /// </summary>
    public void ToCredits()
    {
        SceneManager.LoadScene(m_creditsScene);
    }
    /// <summary>
    /// Exits the Application.
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }
}
