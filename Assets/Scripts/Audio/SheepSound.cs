using UnityEngine;

public class SheepSound : MonoBehaviour
{
    public string sheepSoundName = "sheep_sound_2";
    public float minDelay = 3f;
    public float maxDelay = 8f;

    void Start()
    {
        StartCoroutine(PlayRandmly());
    }

    private System.Collections.IEnumerator PlayRandmly()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            AudioManager.Instance.Play(sheepSoundName);
        }
    }
}
