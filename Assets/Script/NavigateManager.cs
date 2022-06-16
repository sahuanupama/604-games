using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateManager : MonoBehaviour
{

    public string startScreen = "GameStartScreen";
    public string menuScreen = "MenuScreen";
    public string settingsScreen = "SettingScreen";
    public string gameoverScreen = "GameOverScreen";
    public string gamewinScreen = "WinScreen";
    public string gameSeconLevelScreen = "Level-2Scene";

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void WinScreen()
    {
        SceneManager.LoadScene(gamewinScreen);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(startScreen);
    }

    public void LoadSetting()
    {
        SceneManager.LoadScene(settingsScreen);
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadPreviousScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadSecondScene()
    {
        SceneManager.LoadScene("gameLevel-2Scene");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(gameoverScreen);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
