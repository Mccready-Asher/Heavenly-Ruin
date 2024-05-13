using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleScreenController : MonoBehaviour
{
    // Start is called before the first frame update
    //public string destination;
    void Start()
    {
        //SceneManager.LoadScene(destination);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadGame()
    {
        SceneManager.LoadScene("TutorialHall");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
