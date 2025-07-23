using UnityEngine;

public class PlanetaDatos : MonoBehaviour
{
    [Tooltip("Densidad arbitraria para cálculo de gravedad")]
    public float densidad = 5f;

    // Radio calculado automáticamente en tiempo real desde el scale
    public float radio => CalcularRadioDesdeEscala();

    float CalcularRadioDesdeEscala()
    {
        Vector3 escala = transform.localScale;
        return (escala.x + escala.y + escala.z) / 6f; // Promedio del diámetro / 2
    }
}
