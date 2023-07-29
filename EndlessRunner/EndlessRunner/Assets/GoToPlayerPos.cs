using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayerPos : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip audioC;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        audioS.PlayOneShot(audioC);
    }


}
