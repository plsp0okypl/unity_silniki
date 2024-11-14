using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;  // Czu�o�� myszki
    public Transform playerBody;  // Referencja do obiektu gracza

    private float xRotation = 0f;

    void Start()
    {
        // Ukryj kursor i zablokuj go na �rodku ekranu
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Pobierz ruch myszki
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Obr�t w osi X (g�ra/d�) ograniczony, aby unikn�� przekr�cenia g�owy
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Obr�t kamery i cia�a gracza
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Obr�t kamery w pionie
        playerBody.Rotate(Vector3.up * mouseX); // Obr�t gracza w poziomie
    }
}
