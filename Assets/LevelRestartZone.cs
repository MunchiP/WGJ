using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelRestartZone : MonoBehaviour
{
    

 private bool playerInZone = false;

    // Este método lo llamará el Input System cuando se presione E
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed && playerInZone)
        {
            // Aquí puedes hacer sonar un audio desde AudioManager si quieres
            // AudioManager.instance.Play("RestartSound");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInZone = false;
    }


// private bool playerInZone = false;

    //     void Update()
    //     {
    //         // Si el jugador está en la zona y presiona E
    //         if (playerInZone && Input.GetKeyDown(KeyCode.E))
    //         {
    //             // Recargar sonido
    //             AudioManager.Instance.Play("song_level2");
    //             // Recarga la escena actual
    //             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //         }
    //     }

    //     private void OnTriggerEnter2D(Collider2D other)
    //     {
    //         if (other.CompareTag("Player"))
    //         {
    //             playerInZone = true;
    //             Debug.Log("Presiona E para reiniciar el nivel.");
    //         }
    //     }

    //     private void OnTriggerExit2D(Collider2D other)
    //     {
    //         if (other.CompareTag("Player"))
    //         {
    //             playerInZone = false;
    //         }
    //     }
}
