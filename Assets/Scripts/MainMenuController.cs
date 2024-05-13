using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject menu;
    public void ResumeGame()
    {

        menu.GetComponent<Menu>().unPauseGame();

    }

    public void GoToTitle()
    {
         SceneManager.LoadScene("TitleScreen"); //this will have the name of your main game scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
