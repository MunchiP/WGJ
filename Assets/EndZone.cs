using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{

    public static EndZone instance;

    [Header("Tiempo de juego")]
    [SerializeField] private float remainingTime = 60f; // Tiempo inicial en segundos
    [SerializeField] private TextMeshProUGUI countdownTimerTextUI;

    [Header("Escenas")]
    [SerializeField] private string winScene = "WinGame";
    [SerializeField] private string loseScene = "GameOver";

    private bool sceneLoading;

    private void Awake()
    {
        instance = this;

        // Si no se asigna en el inspector, intenta buscarlo en la escena
        if (countdownTimerTextUI == null)
        {
            countdownTimerTextUI = GameObject.Find("CountdownTimerTextUI")?.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        if (sceneLoading) return;

        // Cuenta regresiva
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            VerificarVictoria();
        }

        // Mostrar tiempo en formato mm:ss
        if (countdownTimerTextUI != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countdownTimerTextUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            VerificarVictoria();
        }
    }



public int totalSheep = 3;  // Número total de ovejas que deben cruzar
    private int sheepInside = 0; // Contador de ovejas que han cruzado

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sheep"))
        {
            sheepInside++;

            // Si ya están todas las ovejas dentro, gana inmediatamente
            if (sheepInside >= totalSheep)
            {
                SceneManager.LoadScene(winScene);
            }
        }
    }


    private void VerificarVictoria()
    {
        if (sceneLoading) return;

        sceneLoading = true;
        bool allSaved = SheepCounterManager.instance != null && SheepCounterManager.instance.AllSheepSaved;

        if (allSaved)
        {
            SceneManager.LoadScene(winScene);
        }
        else
        {
            SceneManager.LoadScene(loseScene);
        }
    }

    // Método opcional para cortar el tiempo y forzar carga de escena
    public void StopTimerAndLoad(string sceneName)
    {
        if (sceneLoading) return;

        sceneLoading = true;
        SceneManager.LoadScene(sceneName);
    }
    

}

