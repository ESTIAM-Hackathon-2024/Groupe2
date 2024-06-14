using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;

    public float speed = 6f;
    public float turnSpeed = 360f;
    public float backwardSpeed = 4f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Optional: Prevents the Rigidbody from rotating due to physics
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * vertical;

        if (vertical != 0)
        {
            float currentSpeed = vertical > 0 ? speed : backwardSpeed;
            rb.velocity = new Vector3(moveDirection.x * currentSpeed, rb.velocity.y, moveDirection.z * currentSpeed);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        if (horizontal != 0)
        {
            float turnAmount = horizontal * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turnAmount, 0);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
}
