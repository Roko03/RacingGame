using UnityEngine;

public class CarAIControl : MonoBehaviour
{
    public Transform target;           
    public float speed = 10f;          
    public float turnSpeed = 5f;       
    public float stopDistance = 2f;    

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

        if (distance < stopDistance)
        {
            rb.linearVelocity = Vector3.zero;
            return;
        }

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
    }
}
