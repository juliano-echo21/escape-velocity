using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public float escalaAumentada = 1.1f;
    public float velocidad = 10f;

    private Vector3 escalaOriginal;
    private Vector3 escalaDestino;

    void Start()
    {
        escalaOriginal = transform.localScale;
        escalaDestino = escalaOriginal;
    }

    void Update()
    {
        // Animación suave hacia la escala destino
        transform.localScale = Vector3.Lerp(transform.localScale, escalaDestino, Time.deltaTime * velocidad);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        escalaDestino = escalaOriginal * escalaAumentada;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        escalaDestino = escalaOriginal;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        escalaDestino = escalaOriginal;
    }
}
