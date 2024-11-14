using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Czu³oœæ myszki
    public Transform playerBody;  // Referencja do obiektu gracza

    private float xRotation = 0f;

    void Start()
    {
        // Ukryj kursor i zablokuj go na œrodku ekranu
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Pobierz ruch myszki
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Obrót w osi X (góra/dó³) ograniczony, aby unikn¹æ przekrêcenia g³owy
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Obrót kamery i cia³a gracza
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Obrót kamery w pionie
        playerBody.Rotate(Vector3.up * mouseX); // Obrót gracza w poziomie
    }
}
