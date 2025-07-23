using UnityEngine;

public class glitch : MonoBehaviour
{
    public float intensidad = 2f;       // Qué tanto se mueve (pixeles)
    public float velocidad = 0.05f;     // Cada cuánto se actualiza (segundos)

    private RectTransform rectTransform;
    private Vector2 posicionOriginal;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        posicionOriginal = rectTransform.anchoredPosition;

        InvokeRepeating("ActualizarGlitch", 0f, velocidad);
    }

    void ActualizarGlitch()
    {
        float offsetX = Random.Range(-intensidad, intensidad);
        float offsetY = Random.Range(-intensidad, intensidad);

        rectTransform.anchoredPosition = posicionOriginal + new Vector2(offsetX, offsetY);
    }
}
