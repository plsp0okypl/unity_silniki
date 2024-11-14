using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;   // Prêdkoœæ ruchu
    private Rigidbody rb;      // Referencja do Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Pobierz komponent Rigidbody
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ).normalized * speed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + transform.TransformDirection(move);

        rb.MovePosition(newPosition); // U¿yj MovePosition dla p³ynnego ruchu
    }
}