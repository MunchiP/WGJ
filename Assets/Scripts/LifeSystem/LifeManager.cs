
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
public static LifeManager instance; // Para acceder desde otros scripts

    public int maxLives = 3;
    private int currentLives;

    public Image[] heartsUI;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateHeartsUI();

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("GameOverLight");
        }
    }

    private void UpdateHeartsUI()
    {
        for (int i = 0; i < heartsUI.Length; i++)
        {
            heartsUI[i].enabled = i < currentLives;
        }
    }
}
