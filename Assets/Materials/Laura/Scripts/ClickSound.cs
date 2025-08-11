using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]

public class ClickSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 0f; 
        audioSource.priority = 0;
        audioSource.volume = 1f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

}
