using UnityEngine;

public class PickupHighlight : MonoBehaviour
{
    public float interactionRange = 3f;      // Zasiêg, w którym gracz mo¿e podnieœæ obiekt
    public Material highlightMaterial;       // Materia³ podœwietlenia
    private Material originalMaterial;       // Oryginalny materia³ obiektu
    private Renderer objectRenderer;          // Renderer obiektu

    void Start()
    {
        // Pobranie Renderer obiektu
        objectRenderer = GetComponent<Renderer>();
        // Zapisanie oryginalnego materia³u obiektu
        originalMaterial = objectRenderer.material;
    }

    void Update()
    {
        // Sprawdzamy, czy gracz jest w zasiêgu
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < interactionRange)
        {
            // Podœwietlamy obiekt
            objectRenderer.material = highlightMaterial;

            // Sprawdzamy, czy gracz nacisn¹³ klawisz do podniesienia obiektu
            if (Input.GetKeyDown(KeyCode.E))  // Mo¿esz zmieniæ "E" na inny klawisz
            {
                PickupObject();  // Funkcja do podniesienia obiektu
            }
        }
        else
        {
            // Przywracamy oryginalny materia³, gdy gracz jest poza zasiêgiem
            objectRenderer.material = originalMaterial;
        }
    }

    // Funkcja do podniesienia obiektu
    void PickupObject()
    {
        // Tutaj dodajemy logikê podnoszenia obiektu, np. dodanie do ekwipunku, zmiana pozycji, itp.
        Debug.Log("Obiekt podniesiony!");
    }
}
