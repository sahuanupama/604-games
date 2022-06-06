using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateManager : MonoBehaviour
{

    public string startScreen = "GameStartScreen";
    public string gameoverScreen = "GameOverScreen";
    public string menuScreen = "MenuScreen";
    public string settingsScreen = "SettingScreen";

    // public void LoadFirstScene() { }


    public void LoadGameOver()
    {

        SceneManager.LoadScene(gameoverScreen);
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(startScreen);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(menuScreen);
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
}
