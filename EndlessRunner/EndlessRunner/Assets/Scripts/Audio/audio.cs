using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    bool isPlaying; 

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0 && isPlaying)
        {

            isPlaying = false; 
            GetComponent<AudioSource>().Stop();
        }
        else
        {
            if (isPlaying) return;

            isPlaying = true; 
            GetComponent<AudioSource>().Play();
        }
    }
}
