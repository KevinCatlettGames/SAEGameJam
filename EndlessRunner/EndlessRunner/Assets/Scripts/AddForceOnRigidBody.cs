using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnRigidBody : MonoBehaviour
{
    public Vector2 force;

    public Rigidbody rigidBody;
    bool shot;

    private void Awake()
    {
        if(!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody>();
        }
    }
    private void FixedUpdate()
    {
        if (!shot)
        {
            shot = true;
            rigidBody.AddForce(new Vector2(Random.Range(force.x - 200, force.x + 200), force.y));
        }
    }
}
