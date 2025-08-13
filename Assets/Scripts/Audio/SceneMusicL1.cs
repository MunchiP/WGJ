using UnityEngine;

public class SceneMusicL1 : MonoBehaviour
{
    [SerializeField] string musicName;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            Debug.Log("se reproduce sonido de fondo llamado: " + musicName);
            AudioManager.Instance.PlayMusicLoop(musicName);
        }
    }
}
