using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("GamePlay_");
    }
    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void returnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowStoryAndInstructions()
    {
        SceneManager.LoadScene("Story");
    }
    
}
