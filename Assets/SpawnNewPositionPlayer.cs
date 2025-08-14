using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnNewPositionPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform spawnPoint;

void Start()
{
    if (SceneManager.GetActiveScene().name == "Level2")
    {
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = spawnPoint.position;
            }
        }
    }
}
}
