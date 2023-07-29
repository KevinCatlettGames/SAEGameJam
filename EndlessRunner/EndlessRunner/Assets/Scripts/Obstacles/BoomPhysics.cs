using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomPhysics : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip audioC;

    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        audioS.PlayOneShot(audioC);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 2.5f)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 3f)
        {
            Destroy(gameObject);
        }
    }
}
