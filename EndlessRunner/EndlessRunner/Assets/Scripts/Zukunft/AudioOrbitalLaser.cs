using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOrbitalLaser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
