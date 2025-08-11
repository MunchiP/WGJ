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

    private void Awake()
    {
        instance = this;
        countdownTimerTextUI = GameObject.Find("CountdownTimerTextUI").GetComponent<TextMeshProUGUI>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;

        }
        else if(_remainingTime < 0)
        {
            _remainingTime = 0;
            SceneManager.LoadScene(2);
        }

        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);
        countdownTimerTextUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
