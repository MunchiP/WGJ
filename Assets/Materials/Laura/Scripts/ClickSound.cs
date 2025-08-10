using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ClickSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = clickSound;

        GetComponent<Button>().onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
        Debug.Log("bruum");
    }


}
