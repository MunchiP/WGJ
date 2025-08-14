using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            print(currentScene.name);
            if(currentScene.name == "Story") 
            {
                SceneManager.LoadScene("HowToPlay"); 
            }
            if(currentScene.name == "HowToPlay") 
            {
                SceneManager.LoadScene("GamePlay_"); 
            }

        }
    }
}
