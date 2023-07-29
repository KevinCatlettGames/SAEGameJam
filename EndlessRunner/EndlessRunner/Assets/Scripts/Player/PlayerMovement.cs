using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    // Input Axis
    float horizontal = 0;
    float vertical = 0;

    // Current movement vector
    Vector3 vector;

    // Velocity to apply 
    public float velocity;

    // Border values
    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        vector = new Vector3(horizontal, vertical, 0);
        rb.velocity = vector * velocity;
        rb.position = new Vector2(Mathf.Clamp(rb.position.x, minX, maxX), Mathf.Clamp(rb.position.y, minZ, maxZ));
    }
}