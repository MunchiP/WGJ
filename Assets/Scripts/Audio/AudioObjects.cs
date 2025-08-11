using UnityEngine;

public class AudioObjects : MonoBehaviour
{
    public string sonidoClip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Wool"))
        // {
        //     Debug.Log("Colisión detectada entre " + gameObject.name + " y " + collision.gameObject.name);
        //     AudioManager.Instance.Play(sonidoClip);
        //     // StartCoroutine(AudioManager.Instance.Play(sonidoClip));        
        // }

        PlayerPickUp player = collision.GetComponent<PlayerPickUp>();
        if (player != null && player.carriedObject != null && player.carriedObject.CompareTag("Wool"))
        {
            Debug.Log("Jugador llegó con lana a " + gameObject.name);
            AudioManager.Instance.Play(sonidoClip);
        }
    }

}
