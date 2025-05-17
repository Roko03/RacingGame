using UnityEngine;

public class CarAIControl : MonoBehaviour
{
    public Transform target;            // The waypoint or destination
    public float speed = 10f;           // Forward movement speed
    public float turnSpeed = 5f;        // Rotation speed
    public float stopDistance = 2f;     // How close before stopping

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, target.position);

        // Stop if close enough
        if (distance < stopDistance)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        // Rotate toward target
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        // Move forward
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
}
