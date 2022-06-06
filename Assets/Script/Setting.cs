using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Dropdown dropDown;
    private int _dropDownIndex;
    private Text _selectedText;


    private void Start()
    {
        PlayerPrefs.SetInt("Difficulity", 1);
    }

    // Update is called once per frame
    public void SetDifficulty()
    {
        _dropDownIndex = dropDown.value;
        PlayerPrefs.SetInt("Difficulity", _dropDownIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MenuScreen");
    }

    public void SetColour(GameObject obj)
    {
        var buttoncolour = obj.GetComponent<Image>().color;
        var colourString = $"{buttoncolour.r},{buttoncolour.g},{buttoncolour.b},{buttoncolour.a}";
        PlayerPrefs.SetString("playerColour", colourString);
        PlayerPrefs.Save();
    }
}
