using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    Text timerText;
    [SerializeField] Text BetterTimerText;
    [SerializeField] float totalTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Retriving reference to the specificame object
        GameObject objectWithText = GameObject.Find("txtTimer");

        // Retriving referance to the specific object
        timerText = objectWithText.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
            BetterTimerText.text = totalTime.ToString();
        }

        else
        {
            SceneManager.LoadScene("MenuScreen");
        }

    }
}
