using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAfterDuration : MonoBehaviour
{
    public AudioSource audioS;
    public float duration;
    public AudioClip audioC;

    private void Awake()
    {
        Invoke("PlaySound", duration);
    }

    void PlaySound()
    {
        audioS.PlayOneShot(audioC);
    }
}
