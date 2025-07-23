using UnityEngine;

public class LockCamera : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
