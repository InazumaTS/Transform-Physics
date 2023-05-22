using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LevelSelect1()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelSelect2()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelSelect3()
    {
        SceneManager.LoadScene(3);
    }
    public void LevelSelect4()
    {
        SceneManager.LoadScene(4);
    }
    public void LevelSelect5()
    {
        SceneManager.LoadScene(5);
    }
}
