using UnityEngine;

public class MusicSpawn : MonoBehaviour
{
    [SerializeField] private GameObject musicPrefab;

    void Awake()
    {
        if (Object.FindFirstObjectByType<ConsistencyAudio>() == null)
        {
            Instantiate(musicPrefab);
        }
    }
}
