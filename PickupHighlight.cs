using UnityEngine;

public class PickupHighlight : MonoBehaviour
{
    public float interactionRange = 3f;      // Zasi�g, w kt�rym gracz mo�e podnie�� obiekt
    public Material highlightMaterial;       // Materia� pod�wietlenia
    private Material originalMaterial;       // Oryginalny materia� obiektu
    private Renderer objectRenderer;          // Renderer obiektu

    void Start()
    {
        // Pobranie Renderer obiektu
        objectRenderer = GetComponent<Renderer>();
        // Zapisanie oryginalnego materia�u obiektu
        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        // Sprawdzamy, czy gracz jest w zasi�gu
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < interactionRange)
        {
            // Pod�wietlamy obiekt
            objectRenderer.material = highlightMaterial;

            // Sprawdzamy, czy gracz nacisn�� klawisz do podniesienia obiektu
            if (Input.GetKeyDown(KeyCode.E))  // Mo�esz zmieni� "E" na inny klawisz
            {
                PickupObject();  // Funkcja do podniesienia obiektu
            }
        }
        else
        {
            // Przywracamy oryginalny materia�, gdy gracz jest poza zasi�giem
            objectRenderer.material = originalMaterial;
        }
    }

    // Funkcja do podniesienia obiektu
    void PickupObject()
    {
        // Tutaj dodajemy logik� podnoszenia obiektu, np. dodanie do ekwipunku, zmiana pozycji, itp.
        Debug.Log("Obiekt podniesiony!");
    }
}
