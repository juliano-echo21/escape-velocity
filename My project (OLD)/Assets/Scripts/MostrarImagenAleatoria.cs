using UnityEngine;
using UnityEngine.UI;

public class ImagenAleatoriaLoop : MonoBehaviour
{
    public Sprite[] imagenes;
    private Image imagenUI;
    public float intervalo = 2f;

    void Start()
    {
        imagenUI = GetComponent<Image>();
        InvokeRepeating("CambiarImagen", 0f, intervalo);
    }

    void CambiarImagen()
    {
        if (imagenes.Length > 0)
        {
            int indice = Random.Range(0, imagenes.Length);
            imagenUI.sprite = imagenes[indice];
        }
    }
}
