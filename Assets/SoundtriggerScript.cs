using UnityEngine;

public class SoundTriggerScript : MonoBehaviour
{
    // Referenz auf die Audio Source
    private AudioSource audioSource;

    void Start()
    {
        // Hole die AudioSource-Komponente vom Trigger-Objekt
        audioSource = GetComponent<AudioSource>();
    }

    // Funktion, die ausgelöst wird, wenn der Spieler den Trigger betritt
    void OnTriggerEnter(Collider other)
    {
        // Überprüfe, ob das Objekt, das in den Trigger eintritt, der Spieler ist
        if (other.CompareTag("Player"))
        {
            // Wenn der Spieler den Bereich betritt, spiele den Sound ab
            audioSource.Play();
        }
    }

    // Funktion, die ausgelöst wird, wenn der Spieler den Trigger verlässt
    void OnTriggerExit(Collider other)
    {
        // Überprüfe, ob das Objekt, das den Trigger verlässt, der Spieler ist
        if (other.CompareTag("Player"))
        {
            // Wenn der Spieler den Bereich verlässt, stoppe den Sound
            audioSource.Stop();
        }
    }
}