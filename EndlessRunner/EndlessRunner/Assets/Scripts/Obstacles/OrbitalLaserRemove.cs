using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalLaserRemove : MonoBehaviour
{
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 2.5f)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 2.5f)
        {
            Destroy(gameObject);
        }
    }
}
