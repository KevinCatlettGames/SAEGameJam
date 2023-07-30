using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurmSound : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip audioC;

    public ParticleSystem particleS;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioS.PlayOneShot(audioC);
            particleS.Play();
            Invoke("StopSound", 2f);
         
        }
    }

    void StopSound()
    {
        audioS.Stop();
    }
}
