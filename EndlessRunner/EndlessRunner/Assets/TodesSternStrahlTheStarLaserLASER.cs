using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodesSternStrahlTheStarLaserLASER : MonoBehaviour
{
    public GameObject OrbitalLaser;

    private Rigidbody rb;
    private bool isLanded;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 3)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 3)
        {
            if(isLanded) 
            {
                Instantiate(OrbitalLaser, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            isLanded = true;
        }
    }
}
