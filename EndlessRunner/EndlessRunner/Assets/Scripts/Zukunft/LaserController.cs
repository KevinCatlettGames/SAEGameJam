using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public AudioSource audioS;
    public AudioClip audioC;

    // Start is called before the first frame update
    void Start()
    {
        audioS.PlayOneShot(audioC);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
