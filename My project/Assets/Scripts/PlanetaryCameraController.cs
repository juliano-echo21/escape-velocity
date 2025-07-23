using UnityEngine;

public class PlanetaryCameraController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform jugador;  // Objeto que se observa

    [Header("Configuración de rotación")]
    public float velocidadRotacion = 80f;
    public float velocidadRegreso = 3f;
    public float rangoRotacionX = 30f; // Mirar arriba/abajo
    public float rangoRotacionY = 45f; // Girar a los lados

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    private Quaternion rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        float inputX = 0f;
        float inputY = 0f;
        bool hayInput = false;

        if (Input.GetKey(KeyCode.UpArrow))    { inputX -= 1f; hayInput = true; }
        if (Input.GetKey(KeyCode.DownArrow))  { inputX += 1f; hayInput = true; }
        if (Input.GetKey(KeyCode.LeftArrow))  { inputY -= 1f; hayInput = true; }
        if (Input.GetKey(KeyCode.RightArrow)) { inputY += 1f; hayInput = true; }

        if (hayInput)
        {
            rotacionX += inputX * velocidadRotacion * Time.deltaTime;
            rotacionY += inputY * velocidadRotacion * Time.deltaTime;

            rotacionX = Mathf.Clamp(rotacionX, -rangoRotacionX, rangoRotacionX);
            rotacionY = Mathf.Clamp(rotacionY, -rangoRotacionY, rangoRotacionY);
        }
        else
        {
            rotacionX = Mathf.Lerp(rotacionX, 0f, velocidadRegreso * Time.deltaTime);
            rotacionY = Mathf.Lerp(rotacionY, 0f, velocidadRegreso * Time.deltaTime);
        }

        // Aplicar rotación relativa al jugador
        if (jugador != null)
        {
            Quaternion rotacionExtra = Quaternion.Euler(rotacionX, rotacionY, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, jugador.rotation * rotacionExtra, velocidadRegreso * Time.deltaTime);
        }
    }
}
