using UnityEngine;

public class NewSprite : MonoBehaviour
{
    public Sprite newSpriteOption;
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPickUp player = collision.GetComponent<PlayerPickUp>();
        if (player != null && player.carriedObject != null)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();

            if (sr != null)
            {
                sr.sprite = newSpriteOption;

                GameObject triangle = player.carriedObject;
                player.DropObject(transform.position);
                Destroy(triangle);

            }                
            }
    }
}
