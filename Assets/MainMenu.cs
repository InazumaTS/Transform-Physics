using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if(PlayerPrefs.GetInt("LevelUnlocked") !>1)
        PlayerPrefs.SetInt("LevelUnlocked", 1);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelUnlocked"));
        
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
        if(PlayerPrefs.GetInt("LevelUnlocked")>=2)
        SceneManager.LoadScene(2);
    }
    public void LevelSelect3()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 3)
            SceneManager.LoadScene(3);
    }
    public void LevelSelect4()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 4)
            SceneManager.LoadScene(4);
    }
    public void LevelSelect5()
    {
        if (PlayerPrefs.GetInt("LevelUnlocked") >= 5)
            SceneManager.LoadScene(5);
    }
}
