using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;  // Referenz auf den Character Controller
    public Transform playerCamera;          // Referenz auf die Kamera des Spielers
    public float speed = 12f;               // Bewegungsgeschwindigkeit
    public float gravity = -9.81f;          // Schwerkraft
    public float jumpHeight = 3f;           // Sprunghöhe
    public float mouseSensitivity = 100f;   // Maus-Sensitivität für die Kamerasteuerung

    private float xRotation = 0f;           // Rotation der Kamera um die X-Achse (vertikale Bewegung)
    private Vector3 velocity;               // Zum Speichern der Fallgeschwindigkeit
    private bool isGrounded;                // Zum Überprüfen, ob der Spieler den Boden berührt

    public Transform groundCheck;           // Referenz auf das GroundCheck-Objekt
    public float groundDistance = 0.4f;     // Entfernung zum Boden für die GroundCheck-Kugel
    public LayerMask groundMask;            // Definiert, welche Layer als "Boden" gelten

    void Start()
    {
        // Maus sperren (Cursor in die Mitte des Bildschirms und unsichtbar)
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // ---- Maussteuerung ----
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertikale Kamerabewegung (nach oben/unten schauen)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Begrenzung der vertikalen Drehung

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);  // Rotiert die Kamera
        transform.Rotate(Vector3.up * mouseX);  // Rotiert den Spieler nach links/rechts

        // ---- Spielerbewegung ----
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // Spieler bleibt auf dem Boden (begrenzt die Geschwindigkeit nach unten)
        }

        // Bewegung in die Richtungen vorwärts, rückwärts, seitlich (WASD-Steuerung)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Sprunglogik (wird ausgelöst, wenn der Spieler am Boden ist und die Sprungtaste drückt)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // Berechnet die Sprunghöhe
        }

        // Schwerkraft anwenden
        velocity.y += gravity * Time.deltaTime;

        // Anwenden der Schwerkraftbewegung
        controller.Move(velocity * Time.deltaTime);
    }
}