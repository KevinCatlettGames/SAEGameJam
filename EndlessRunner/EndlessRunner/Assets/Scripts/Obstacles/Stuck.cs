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

    //private float timer = 0;
    //private bool isOnce = true;

    private Vector3 vector3DistanceBetweenArrowAndPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rb_main = GetComponent<Rigidbody>();
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
            gameObject.transform.position = playerTransform.position + vector3DistanceBetweenArrowAndPlayer;
        }
        //if (timer < 1)
        //{
        //    timer += Time.deltaTime;
        //}
        //if (timer >= 1)
        //{
        //    if (isOnce)
        //    {
        //        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
        //    }
        //    isOnce = false;
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            GetComponent<Rotate>().enabled = false;
            rb_main.constraints = RigidbodyConstraints.FreezeAll;
            isFall = false;
        }
        if (other.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            GetComponent<Rotate>().enabled = false;
            rb_main.constraints = RigidbodyConstraints.FreezeAll;
            isFall = false;
            isStuckOnPlayer = true;
            vector3DistanceBetweenArrowAndPlayer = playerTransform.position - gameObject.transform.position;
        }
    }
}
