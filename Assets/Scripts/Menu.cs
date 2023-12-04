using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject[] buttons;
   public void ToGame()
    {
        SceneManager.LoadScene("TestingRoom");
    }

    public void Quit()
    {
        Debug.Log("Leaving Buh-Bye");
        Application.Quit();
    }

    public void Settings()
    {
        //show the settings
        settingsScreen.SetActive(true);
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }

    }

    public void Back()
    {
        settingsScreen.SetActive(false);
        foreach (var button in buttons)
        {
            button.SetActive(true);
        }

    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
