
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Singleton: accede de manera facil desde otros scripts
    public static AudioManager Instance;
    // La clase interna -sound- es visible en el inspector
    [System.Serializable]
    public class Sound
    {
        public string name; // Nombre para identificar el sonido
        public UnityEngine.AudioClip clip; //Archivo del audio que se va a reproducir
        [Range(0.5f, 1f)] public float volumen = 1f; // Rango del volumen que se reproduce
    }

    // Lista de los sonidos que se agregan en el inspector
    public List<Sound> sounds = new List<Sound>();

    // El audioSourcee que reproducirá los sonidos
    private AudioSource audioSource;

    private void Awake()
    {
        // Configuración inicial del sistema
        if (Instance == null)
        {
            Instance = this; // Si no hay ninguna otra instancia, esta es la inicial
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); // en caso de que existra otro, lo destruye
            return;
        }

        // Obtiene el AudioSource adjunto al GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // -M- Método que reproduce el sonido según el nombre
    //  public IEnumerator Play(string sonidoNombre)
    // {
    //     Sound sonido = sounds.Find(x => x.name == sonidoNombre); // Lo busca en la lista

    //     if (sonido != null) // Es difererente de nulo
    //     {
    //         audioSource.PlayOneShot(sonido.clip, sonido.volumen); // Lo reproduzco una sola vez "shot"
    //         yield return new WaitForSeconds(sonido.clip.length);
    //     } else 
    //     {
    //         Debug.LogWarning("Encontró sonido:" + sonidoNombre);
    //         yield return new WaitForSeconds(1f);
    //     }
    // }

    public void Play(string sonidoNombre)
    {
        Sound sonido = sounds.Find(x => x.name == sonidoNombre);

        if (sonido != null)
        {
            // Debug.Log("Nombre: " + sonidoNombre + " sound: " + sonido );
            audioSource.PlayOneShot(sonido.clip, sonido.volumen);
            // audioSource.clip = sonido.clip;
            // audioSource.volume = sonido.volumen;
            // audioSource.loop = true;
            // audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se encontró el sonido: " + sonidoNombre);
        }

    }

    // Reproducción de cada uno los clipsssssss
    public float GetClipLength(string name)
    {
        UnityEngine.AudioClip clip = sounds.Find(s => s.name == name)?.clip;
        return clip != null ? clip.length : 1f;
    }


    //Reproduccion de musica de fondo
    public void PlayMusicLoop(string sonidoNombre)
    {
        Sound sonido = sounds.Find(x => x.name == sonidoNombre);

        if (sonido != null)
        {
            audioSource.clip = sonido.clip;
            audioSource.volume = sonido.volumen;
            audioSource.loop = true; // esto hace que se repita
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No se encontró la música: " + sonidoNombre);
        }
    }
}
