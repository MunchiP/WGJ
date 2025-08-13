using UnityEngine;

public class JarsMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Check if a Rigidbody exists to prevent errors
        if (rb == null)
            Debug.LogWarning("No Rigidbody found on this GameObject.");
 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Item")
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}
