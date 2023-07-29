using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyAfter250MS : MonoBehaviour
{
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 2.5f)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 2.5f)
        {
            Destroy(gameObject);
        }
    }
}
