using UnityEngine;

public class SteeringWheelController : MonoBehaviour
{
    [SerializeField] private Transform steeringWheelTransform;
    [SerializeField] private float maxSteerAngle = 450f; // maksimalni kut rotacije volana

    private void Update()
    {
        float steerInput = Input.GetAxis("Horizontal");
        float steerAngle = steerInput * maxSteerAngle;

        // Rotacija volana oko lokalne Z osi
        steeringWheelTransform.localRotation = Quaternion.Euler(0f, 0f, steerAngle);
    }
}
