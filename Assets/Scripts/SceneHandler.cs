using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField]
    private string m_menuScene = "MenuScene";
    [SerializeField]
    private string m_gameScene = "MainScene";
    //Credits?
    public void ToMenu()
    {
        SceneManager.LoadScene(m_menuScene);
    }
    public void ToGame()
    {
        SceneManager.LoadScene(m_gameScene);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
