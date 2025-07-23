using UnityEngine;

public class bamboleo : MonoBehaviour
{
    public float anguloMaximo = 10f; // Hasta cuántos grados bambolea
    public float velocidad = 2f;     // Qué tan rápido bambolea

    private RectTransform rectTransform;
    private float rotacionInicialZ;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Guardamos la rotación original en Z
        rotacionInicialZ = rectTransform.eulerAngles.z;
    }

    void Update()
    {
        // Movimiento suave entre -ángulo y +ángulo
        float angulo = Mathf.Sin(Time.time * velocidad) * anguloMaximo;

        // Sumamos ese ángulo a la rotación original (en Z)
        rectTransform.rotation = Quaternion.Euler(0f, 0f, rotacionInicialZ + angulo);
    }
}
