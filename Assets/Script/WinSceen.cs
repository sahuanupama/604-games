using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceen : MonoBehaviour
{
    public void playagain()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
