using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stuck : MonoBehaviour
{
    private bool isFall = true;
    public Rigidbody rb_main;
    public bool isStuckOnPlayer = false;
    public Transform playerTransform;

    private Vector3 vector3DistanceBetweenArrowAndPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rb_main = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall)
        {
            gameObject.transform.rotation = Quaternion.LookRotation(rb_main.velocity);
        }
        if (isStuckOnPlayer)
        {
            gameObject.transform.position = playerTransform.position - vector3DistanceBetweenArrowAndPlayer;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GetComponent<Rotate>().enabled = false;
            rb_main.constraints = RigidbodyConstraints.FreezeAll;
            isFall = false;
        }
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Rotate>().enabled = false;
            rb_main.constraints = RigidbodyConstraints.FreezeAll;
            isFall = false;
            isStuckOnPlayer = true;
            vector3DistanceBetweenArrowAndPlayer = playerTransform.position - gameObject.transform.position;
        }
    }
}
