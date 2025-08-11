using UnityEngine;

public class NewSprite : MonoBehaviour
{
    public Sprite newSpriteOption;
    public string sonidoClip;
     void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerPickUp player = collision.GetComponent<PlayerPickUp>();

        // Verificar si el jugador existe y lleva un objeto con tag Wool
        if (player != null && player.carriedObject != null && player.carriedObject.CompareTag("Wool"))
        {
            // Cambiar sprite de la oveja
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.sprite = newSpriteOption;

            // Destruir la lana
            GameObject triangle = player.carriedObject;
            player.DropObject(transform.position);
            Destroy(triangle);

            // Reproducir sonido
            if (AudioManager.Instance != null && !string.IsNullOrEmpty(sonidoClip))
                AudioManager.Instance.Play(sonidoClip);

            // codigo para que se relacione con el de Diana y le diga que isWaiting es falsooo

            WaypointNPCMover mover = GetComponent<WaypointNPCMover>();
            if (mover != null)
            {
                mover.IsWaiting = false;
            }
            }
        }



    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     PlayerPickUp player = collision.GetComponent<PlayerPickUp>();
    //     if (player != null && player.carriedObject != null)
    //     {
    //         SpriteRenderer sr = GetComponent<SpriteRenderer>();

    //         if (sr != null)
    //         {
    //             sr.sprite = newSpriteOption;

    //             GameObject triangle = player.carriedObject;
    //             player.DropObject(transform.position);
    //             Destroy(triangle);

    //         }                
    //         }
    // }
}
