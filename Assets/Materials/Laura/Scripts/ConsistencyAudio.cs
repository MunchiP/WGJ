using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsistencyAudio : MonoBehaviour
{
    private static ConsistencyAudio instance;
    [SerializeField] private int[] allowedSceneIDs = {0,1,4};

    void Awake()
    {
        //helps to not overloap the sound when opening a new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool isValidScene = false;

        foreach (int sceneID in allowedSceneIDs)
        {
            if (scene.buildIndex == sceneID)
            {
                isValidScene = true;
                break;
            }
        }

        if (!isValidScene)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded; 
            instance = null;                           
            Destroy(gameObject);
        }
    }


}
