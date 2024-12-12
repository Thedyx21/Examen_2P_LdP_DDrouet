using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public AudioClip objectHitSound; // Sonido al golpear el suelo
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto tiene la etiqueta "FallingObject"
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            // Reproducir sonido al golpear el suelo
            if (objectHitSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(objectHitSound);
            }

            // Destruir el objeto que golpeó el suelo
            Destroy(collision.gameObject);
        }
    }
}
