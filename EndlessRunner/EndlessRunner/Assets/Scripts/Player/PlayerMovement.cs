using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody physics;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float vel;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // public float slope;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        vec = new Vector3(horizontal, vertical, 0);
        physics.velocity = vec * vel;
        physics.position = new Vector2
            (
            Mathf.Clamp(physics.position.x, minX, maxX),
            Mathf.Clamp(physics.position.y, minZ, maxZ)
            );
      //  physics.rotation = Quaternion.Euler(0, 0, physics.velocity.x * -slope);

    }

}