using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAScript : MonoBehaviour
{
    public int levelAToLoad;
    public int boxcounter = 0, counter = 0;
    public float dropdownSpeed = -2;
    public bool useIntegerToLoadLevel = false;
    public float playerSpeed = 1f;
    public float halfPlayerSize = 0.5f;
    public float screenSizeY;
    public float screenSizeX;
    [SerializeField] Camera MainCamera;
    [SerializeField] float joyHorizontal;
    [SerializeField] float joyVertical;

    // Start is called before the first frame update
    private void Start()
    {
        screenSizeY = MainCamera.orthographicSize * 2;
        screenSizeX = screenSizeY * Screen.width / Screen.height;
        // ScoreManager.instance.AddPoints();

        if (PlayerPrefs.GetInt("Difficulty").Equals(0))
        {
            dropdownSpeed = -2;
        }
        else if (PlayerPrefs.GetInt("Difficulty").Equals(1))
        {
            dropdownSpeed = -4;
        }
        else
        {
            dropdownSpeed = -6;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Toffe") || collision.gameObject.CompareTag("Coin"))
        {
            boxcounter++;
            Destroy(collision.gameObject);
            if (boxcounter == 10)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
        else if (collision.gameObject.CompareTag("Pirate"))
        {
            counter++;
            Destroy(collision.gameObject);
            if (counter == 5)
            {
                SceneManager.LoadScene("GameOver");
            }
        }

    }

    /*void LoadScene()
    {
        if (useIntegerToLoadLevel)
        {
            SceneManager.LoadScene(ilevelToLoad);
        }
        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }*/

    public void playnext()
    {
        SceneManager.LoadScene("Level-2Scene");
    }
}

