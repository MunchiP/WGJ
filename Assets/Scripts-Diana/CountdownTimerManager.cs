using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimerManager : MonoBehaviour
{
    public static CountdownTimerManager instance;

    private TextMeshProUGUI countdownTimerTextUI;
    [SerializeField]
    float _remainingTime;
    public float RemainingTime { set => _remainingTime = value; }  //Si quiere usarse para modificar la dificultad

    //**
    //AGregado en el codigo de Diana para evitar cargas repetidas
    private bool sceneLoading;
    //**


    private void Awake()
    {
        instance = this;
        countdownTimerTextUI = GameObject.Find("CountdownTimerTextUI").GetComponent<TextMeshProUGUI>();
    }


    // Update is called once per frame
    void Update()
    {

        //**
        if (sceneLoading)
        {
            return;
        }
        //**
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;

        }
        else
        {
            _remainingTime = 0;
            bool allSaved = SheepCounterManager.instance != null && SheepCounterManager.instance.AllSheepSaved;

            sceneLoading = true;
            if (allSaved)
            {
                SceneManager.LoadScene("Level2");
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }

        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);
        countdownTimerTextUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        // else if (_remainingTime < 0)
        // {
        //     _remainingTime = 0;
        //     SceneManager.LoadScene(2);
        // }

        // int minutes = Mathf.FloorToInt(_remainingTime / 60);
        // int seconds = Mathf.FloorToInt(_remainingTime % 60);
        // countdownTimerTextUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //Para que se cargue la nueva scena y no tenga que esperar que se acabe el tiempo
    public void StopTimerAndLoad(string sceneName)
        {
            if (sceneLoading) return;

            sceneLoading = true;
            SceneManager.LoadScene(sceneName);
        }
}
