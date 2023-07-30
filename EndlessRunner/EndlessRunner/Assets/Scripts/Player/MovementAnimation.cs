using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    public Transform transform;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        transform.eulerAngles = new UnityEngine.Vector3(-90, 0, -180);
    }

    // Update is called once per frame
    void Update()
    {
        MoveAnimation();
    }
    void MoveAnimation()
    {
        if (rb.velocity.x == 0) //standing horizontally
        {
            transform.eulerAngles = new UnityEngine.Vector3(-90, transform.rotation.y, transform.rotation.z);
        }
        if (rb.velocity.y == 0) //standing vertically
        {
            transform.eulerAngles = new UnityEngine.Vector3(transform.rotation.x, transform.rotation.y, -180);
        }
        if (rb.velocity.x > 0) //towards right
        {
            transform.eulerAngles = new UnityEngine.Vector3(transform.rotation.x, transform.rotation.y, -180);
        }
        if (rb.velocity.x < 0) //towards left
        {
            transform.eulerAngles = new UnityEngine.Vector3(transform.rotation.x, transform.rotation.y, -180);
        }
        if (rb.velocity.y > 0) //towards up
        {
            transform.eulerAngles = new UnityEngine.Vector3(-80, transform.rotation.y, transform.rotation.z);
        }
        if (rb.velocity.y < 0) //towards down
        {
            transform.eulerAngles = new UnityEngine.Vector3(-100, transform.rotation.y, transform.rotation.z);
        }   
        
    }
}
