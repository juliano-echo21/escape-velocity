using UnityEngine;

public class JetpackController : MonoBehaviour
{
    public ParticleSystem jetpackBurst;

    void Start()
    {
        jetpackBurst.Stop();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jetpackBurst.Play();
        }
    }
}
