using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void credits()
    {
        SceneManager.LoadScene(5);
    }
    public void returnMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
