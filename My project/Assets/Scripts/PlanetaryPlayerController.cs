using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlanetaryPlayerController : MonoBehaviour
{
    public GameObject[] planetas;
    public float fuerzaSalto = 8f;
    public float velocidadMovimiento = 12f;
    public float friccionMovimiento = 10f;
    public float multiplicadorFrenado = 0.95f;
    public float constanteInfluencia = 2.5f;

    public float velocidadTransicion = 5f;

    private Transform planetaActual;
    private Transform planetaAnterior;
    private Rigidbody rb;

    private Vector3 direccionGravedadSuave;
    private float gravedadSuave;
    private float factorTransicion = 1f;

    // 🎯 NUEVO: Animator y control de estado
    private Animator animator;
    private bool estaCorriendo = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.freezeRotation = true;
        rb.drag = 2f;
        rb.angularDrag = 5f;

        direccionGravedadSuave = Vector3.down;

        // 🎯 Inicializar Animator
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Transform nuevoPlaneta = ObtenerPlanetaPorInfluencia();
        if (nuevoPlaneta != planetaActual && nuevoPlaneta != null)
        {
            planetaAnterior = planetaActual;
            planetaActual = nuevoPlaneta;
            factorTransicion = 0f;
        }

        // 🎯 Detectar salto
        if (Input.GetButtonDown("Jump") && planetaActual != null)
        {
            Vector3 direccionSalto = -direccionGravedadSuave;
            rb.AddForce(direccionSalto * fuerzaSalto, ForceMode.Impulse);

            // 🎯 Animación de despegue
            if (!EstaEnSuelo() || Input.GetButtonDown("Jump"))
            {
                animator.SetTrigger("jumps");
                animator.ResetTrigger("lands");
                animator.SetBool("isFalling", true);
            }
        }

        // 🎯 Verificar aterrizaje
        if (EstaEnSuelo())
        {
            animator.SetTrigger("lands");
            animator.ResetTrigger("jumps");
            animator.SetBool("isFalling", false);
        }

        // 🎯 Estado de movimiento
        bool estaMoviendose = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        if (estaMoviendose != estaCorriendo)
        {
            estaCorriendo = estaMoviendose;
            animator.SetBool("isRunning", estaCorriendo);
        }
    }

    void FixedUpdate()
    {
        if (planetaActual == null) return;

        Vector3 direccionObjetivo = (planetaActual.position - transform.position).normalized;
        float gravedadObjetivo = CalcularGravedad(planetaActual);

        if (factorTransicion < 1f)
        {
            factorTransicion += velocidadTransicion * Time.fixedDeltaTime;
            factorTransicion = Mathf.Clamp01(factorTransicion);
        }

        if (planetaAnterior != null && factorTransicion < 1f)
        {
            Vector3 direccionAnterior = (planetaAnterior.position - transform.position).normalized;
            float gravedadAnterior = CalcularGravedad(planetaAnterior);

            direccionGravedadSuave = Vector3.Slerp(direccionAnterior, direccionObjetivo, factorTransicion);
            gravedadSuave = Mathf.Lerp(gravedadAnterior, gravedadObjetivo, factorTransicion);
        }
        else
        {
            direccionGravedadSuave = Vector3.Slerp(direccionGravedadSuave, direccionObjetivo, velocidadTransicion * Time.fixedDeltaTime);
            gravedadSuave = Mathf.Lerp(gravedadSuave, gravedadObjetivo, velocidadTransicion * Time.fixedDeltaTime);
        }

        rb.AddForce(direccionGravedadSuave * gravedadSuave, ForceMode.Acceleration);

        Quaternion rotacionObjetivo = Quaternion.FromToRotation(transform.up, -direccionGravedadSuave) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, 10f * Time.fixedDeltaTime);

        float h = Input.GetKey(KeyCode.A) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;
        float v = Input.GetKey(KeyCode.S) ? 1f : Input.GetKey(KeyCode.W) ? -1f : 0f;

        if (h != 0f)
        {
            float velocidadRotacion = 50f;
            transform.Rotate(Vector3.up, h * velocidadRotacion * Time.fixedDeltaTime, Space.Self);
        }

        Vector3 forward = Vector3.Cross(transform.right, direccionGravedadSuave);
        Vector3 right = Vector3.Cross(direccionGravedadSuave, forward);
        Vector3 direccionMovimiento = (forward * v + right * h).normalized;

        if (direccionMovimiento != Vector3.zero)
        {
            Vector3 fuerzaMovimiento = direccionMovimiento * velocidadMovimiento * friccionMovimiento;
            rb.AddForce(fuerzaMovimiento, ForceMode.Acceleration);

            Vector3 velocidadHorizontal = Vector3.ProjectOnPlane(rb.velocity, -direccionGravedadSuave);
            Vector3 velocidadVertical = Vector3.Project(rb.velocity, -direccionGravedadSuave);
            velocidadHorizontal *= multiplicadorFrenado;

            if (velocidadHorizontal.magnitude < 0.1f)
                velocidadHorizontal = Vector3.zero;

            rb.velocity = velocidadHorizontal + velocidadVertical;
        }
    }

    // 🎯 Función para detectar si está en el suelo
    bool EstaEnSuelo()
    {
        Ray ray = new Ray(transform.position, direccionGravedadSuave);
        return Physics.Raycast(ray, out _, 0.35f);
    }
    
    Transform ObtenerPlanetaPorInfluencia()
    {
        Transform mejorPlaneta = null;
        float mejorGravedad = 0f;

        foreach (var planeta in planetas)
        {
            PlanetaDatos datos = planeta.GetComponent<PlanetaDatos>();
            if (datos == null) continue;

            float masa = CalcularMasa(datos);
            float distancia = Vector3.Distance(transform.position, planeta.transform.position);
            float radioInfluencia = constanteInfluencia * Mathf.Sqrt(masa);

            if (distancia <= radioInfluencia)
            {
                float gravedad = masa / (distancia * distancia);
                if (gravedad > mejorGravedad)
                {
                    mejorGravedad = gravedad;
                    mejorPlaneta = planeta.transform;
                }
            }
        }
        return mejorPlaneta;
    }

    float CalcularGravedad(Transform planeta)
    {
        PlanetaDatos datos = planeta.GetComponent<PlanetaDatos>();
        if (datos == null) return 10f;

        float masa = CalcularMasa(datos) / 15;
        float distancia = Vector3.Distance(transform.position, planeta.position) + datos.radio;
        float gravedad = masa / (distancia * distancia);
        return Mathf.Clamp(gravedad, 10f, gravedad);
    }

    float CalcularMasa(PlanetaDatos datos)
    {
        float volumen = (4f / 3f) * Mathf.PI * Mathf.Pow(datos.radio, 3);
        return datos.densidad * volumen;
    }
}
