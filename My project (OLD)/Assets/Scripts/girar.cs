using UnityEngine;

public class NewEmptyCSharpScript : MonoBehaviour
{
    public float amplitud = 20f;         // Qué tanto se mueve (arriba y abajo)
    public float velocidad = 2f;         // Qué tan rápido se mueve
    public float velocidadRotacion = 30f; // Qué tan rápido gira (grados por segundo)

    private RectTransform rectTransform;
    private Vector2 posicionInicial;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        posicionInicial = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Movimiento vertical en bucle (senoidal)
        float desplazamiento = Mathf.Sin(Time.time * velocidad) * amplitud;
        rectTransform.anchoredPosition = posicionInicial + new Vector2(0f, desplazamiento);

        // Rotación suave
        rectTransform.Rotate(0f, 0f, velocidadRotacion * Time.deltaTime);
    }
}
