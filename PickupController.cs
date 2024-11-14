using UnityEngine;

public class PickupController : MonoBehaviour
{
    public Transform holdPosition;  // Pozycja, w której obiekt bêdzie trzymany
    public float pickupRange = 3f;  // Zasiêg podnoszenia obiektów
    public float throwForce = 10f;  // Si³a rzutu

    private GameObject pickedObject; // Obiekt aktualnie podniesiony

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Klawisz interakcji
        {
            if (pickedObject == null)
            {
                TryPickup();
            }
            else
            {
                DropObject();
            }
        }

        if (Input.GetMouseButtonDown(1) && pickedObject != null) // Prawy przycisk myszy do rzucania
        {
            ThrowObject();
        }
    }

    void TryPickup()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Pickupable"))
            {
                pickedObject = hit.collider.gameObject;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
                pickedObject.transform.position = holdPosition.position;
                pickedObject.transform.SetParent(holdPosition);
            }
        }
    }

    void DropObject()
    {
        pickedObject.GetComponent<Rigidbody>().isKinematic = false;
        pickedObject.transform.SetParent(null);
        pickedObject = null;
    }

    void ThrowObject()
    {
        Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        pickedObject.transform.SetParent(null);
        rb.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
        pickedObject = null;
    }
}

