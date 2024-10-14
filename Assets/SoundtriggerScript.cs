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

    // Funktion, die ausgel�st wird, wenn der Spieler den Trigger betritt
    void OnTriggerEnter(Collider other)
    {
        // �berpr�fe, ob das Objekt, das in den Trigger eintritt, der Spieler ist
        if (other.CompareTag("Player"))
        {
            // Wenn der Spieler den Bereich betritt, spiele den Sound ab
            audioSource.Play();
        }
    }

    // Funktion, die ausgel�st wird, wenn der Spieler den Trigger verl�sst
    void OnTriggerExit(Collider other)
    {
        // �berpr�fe, ob das Objekt, das den Trigger verl�sst, der Spieler ist
        if (other.CompareTag("Player"))
        {
            // Wenn der Spieler den Bereich verl�sst, stoppe den Sound
            audioSource.Stop();
        }
    }
}