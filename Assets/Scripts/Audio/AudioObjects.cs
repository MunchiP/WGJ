using UnityEngine;

public class AudioObjects : MonoBehaviour
{
    public string sonidoClip;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colisión detectada entre " + gameObject.name + " y " + collision.gameObject.name);
            AudioManager.Instance.Play(sonidoClip);   
            // StartCoroutine(AudioManager.Instance.Play(sonidoClip));        
        }
    }
}
